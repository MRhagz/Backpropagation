using Backprop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Training;
using Training.SimulatedAnnealing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Backpropagation
{
    public partial class Form1 : Form
    {
        private NeuralNet neural_network;
        private CancellationTokenSource trainingCts;
        private int n_epoch;
        private bool batchLearning;

        private static double[][] inputs = new double[][]
        {
            new double[] {0,0,0,0}, new double[] {0,0,0,1}, new double[] {0,0,1,0}, new double[] {0,0,1,1},
            new double[] {0,1,0,0}, new double[] {0,1,0,1}, new double[] {0,1,1,0}, new double[] {0,1,1,1},
            new double[] {1,0,0,0}, new double[] {1,0,0,1}, new double[] {1,0,1,0}, new double[] {1,0,1,1},
            new double[] {1,1,0,0}, new double[] {1,1,0,1}, new double[] {1,1,1,0}, new double[] {1,1,1,1}
        };

        private static double[] targets = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

        public Form1()
        {
            InitializeComponent();
            neural_network = null;
            trainingCts = null;
            n_epoch = 0;
            batchLearning = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            const int numberOfInput = 4;
            const int numberOfOutput = 1;

            int numberOfHiddenNeurons = Convert.ToInt32(numberOfHN.Value);
            if (numberOfHiddenNeurons < 1)
            {
                MessageBox.Show("Number of hidden neurons must be at least 1.");
                return;
            }

            n_epoch = 0;
            neural_network = new NeuralNet(numberOfInput, numberOfHiddenNeurons, numberOfOutput);
            resetUI();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (neural_network == null)
            {
                MessageBox.Show("Please create the neural network first.");
                return;
            }

            // Apply inputs once before training starts
            bool _input1 = input1.Checked;
            bool _input2 = input2.Checked;
            bool _input3 = input3.Checked;
            bool _input4 = input4.Checked;

            neural_network.setInputs(0, Convert.ToDouble(_input1));
            neural_network.setInputs(1, Convert.ToDouble(_input2));
            neural_network.setInputs(2, Convert.ToDouble(_input3));
            neural_network.setInputs(3, Convert.ToDouble(_input4));

            // Perform one learning epoch (potentially CPU-bound)
            neural_network.run();

            double output = Math.Round(neural_network.getOuputData(0), 4);

            outputNeuron.Text = output.ToString();
        }

        private void resetUI()
        {
            input1.Checked = false;
            input2.Checked = false;
            input3.Checked = false;
            input4.Checked = false;

            epoch.Text = "...";
            outputNeuron.Text = "...";
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            // Single-step learn (keeps previous behavior)
            if (neural_network == null)
            {
                MessageBox.Show("Please create the neural network first.");
                return;
            }

            

            

            // Prevent re-entrancy: if training already running, ignore the request
            if (trainingCts != null)
            {
                MessageBox.Show("Training is already running.");
                return;
            }
            
            // Disable controls that should not be used during training

            numberOfHN.Enabled = false;
            numberOfE.Enabled = false;
            input1.Enabled = false;
            input2.Enabled = false;
            input3.Enabled = false;
            input4.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;

            trainingCts = new CancellationTokenSource();
            CancellationToken token = trainingCts.Token;
            Random rand = new Random();

            int batchSize = Convert.ToInt32(numberOfE.Value);
            try
            {
                await Task.Run(() =>
                {
                    if (batchLearning)
                    {
                        for (int i = 0; i < batchSize; i++)
                        {
                            token.ThrowIfCancellationRequested();


                            for (int j = 0; j < 16; j++)
                            {
                                neural_network.setInputs(0, inputs[j][0]);
                                neural_network.setInputs(1, inputs[j][1]);
                                neural_network.setInputs(2, inputs[j][2]);
                                neural_network.setInputs(3, inputs[j][3]);
                                Console.WriteLine(targets[j]);
                                neural_network.setDesiredOutput(0, targets[j]);
                                neural_network.learn();
                            }
           
                            n_epoch++;
                            double output = Math.Round(neural_network.getOuputData(0), 4);
                            try
                            {
                                this.Invoke((Action)(() =>
                                {
                                    outputNeuron.Text = output.ToString();
                                    epoch.Text = n_epoch.ToString();
                                }));
                            }
                            catch (ObjectDisposedException)
                            {
                                // Form is closing/disposed, break out
                                return;
                            }
                            Thread.Sleep(1);
                        }
                    }
                    else
                    {
                        bool _input1 = input1.Checked;
                        bool _input2 = input2.Checked;
                        bool _input3 = input3.Checked;
                        bool _input4 = input4.Checked;
                        int desiredOutput = (_input1 && _input2 && _input3 && _input4) ? 1 : 0;
                        neural_network.setDesiredOutput(0, desiredOutput);
                        neural_network.learn();
                        n_epoch++;
                        double output = Math.Round(neural_network.getOuputData(0), 4);

                        try
                        {
                            this.Invoke((Action)(() =>
                            {
                                outputNeuron.Text = output.ToString();
                                epoch.Text = n_epoch.ToString();
                            }));
                        }
                        catch (ObjectDisposedException)
                        {
                            // Form is closing/disposed, break out
                            return;
                        }

                        batchLearning = false;

                        
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
                // Training was cancelled; optionally update UI to reoutlect cancellation
                this.Invoke((Action)(() =>
                {
                    epoch.Text = "Cancelled";
                }));
            }
            catch (Exception ex)
            {
                // Report unexpected errors
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show("Training error: " + ex.Message);
                }));
            }
            finally
            {
                // Clean up and re-enable controls
                trainingCts.Dispose();
                trainingCts = null;

                numberOfHN.Enabled = true;
                numberOfE.Enabled = true;
                input1.Enabled = true;
                input2.Enabled = true;
                input3.Enabled = true;
                input4.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int numberOfEpochs = Convert.ToInt32(numberOfE.Value);
            if (numberOfEpochs < 1)
            {
                MessageBox.Show("Number of epochs must be at least 1.");
                return;
            }
            batchLearning = true;
            button1.PerformClick();
        }
    }
}
