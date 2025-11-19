using System;
using System.Collections.Generic;
using System.Linq;
using Backprop;

namespace Training.SimulatedAnnealing
{
    // 1. Define the boundaries for our hyperparameters
    public struct HyperParameters
    {
        public int Epochs;
        public int HiddenNeurons;

        public override string ToString()
        {
            return $"Epochs: {Epochs}, Neurons: {HiddenNeurons}";
        }
    }

    class Program
    {
        // 4-Input AND Gate Data (16 combinations)
        static double[][] inputs = new double[][]
        {
            new double[] {0,0,0,0}, new double[] {0,0,0,1}, new double[] {0,0,1,0}, new double[] {0,0,1,1},
            new double[] {0,1,0,0}, new double[] {0,1,0,1}, new double[] {0,1,1,0}, new double[] {0,1,1,1},
            new double[] {1,0,0,0}, new double[] {1,0,0,1}, new double[] {1,0,1,0}, new double[] {1,0,1,1},
            new double[] {1,1,0,0}, new double[] {1,1,0,1}, new double[] {1,1,1,0}, new double[] {1,1,1,1}
        };

        // Target: 1 only if all inputs are 1
        static double[] targets = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

        static void Main(string[] args)
        {
            Console.WriteLine("--- Neural Network Hyperparameter Optimization ---");
            Console.WriteLine("Problem: 4-Input AND Gate");

            // Run the algorithm
            HyperParameters optimal = SimulatedAnnealingSearch();

            Console.WriteLine("\n--- Final Result ---");
            Console.WriteLine($"Best Configuration Found: {optimal}");
            double finalLoss = TrainAndEvaluate(optimal);
            Console.WriteLine($"Final Loss (MSE): {finalLoss:F6}");

            // Demonstrate the best network
            Console.WriteLine("\nTesting best network prediction on '1,1,1,1':");
            NeuralNet nn = new NeuralNet(4, optimal.HiddenNeurons, 1);
            Train(nn, inputs, targets, optimal.Epochs);
            double prediction = Forward(nn, new double[] { 1, 1, 1, 1 });
            Console.WriteLine($"Input: 1 1 1 1 | Output: {prediction:F4} (Target: 1.0)");
        }

        // --- Train

        private static double Forward(NeuralNet nn, double[] input)
        {
            nn.setInputs(0, input[0]);
            nn.setInputs(1, input[1]);
            nn.setInputs(2, input[2]);
            nn.setInputs(3, input[3]);
            nn.run();
            return nn.getOuputData(0);
        }
        private static void Train(NeuralNet nn, double[][] inputs, double[] targets, int epochs)
        {
            for (int epoch = 0; epoch < epochs; epoch++)
                for (int i = 0; i < inputs.Length; i++) {
                    double[] input = inputs[i];

                    nn.setInputs(0, input[0]);
                    nn.setInputs(1, input[1]);
                    nn.setInputs(2, input[2]);
                    nn.setInputs(3, input[3]);
                    nn.setDesiredOutput(0, targets[i]);
                    nn.run();
                    nn.learn();
                }
        }

        // --- THE OPTIMIZATION ALGORITHM (Simulated Annealing) ---
        static HyperParameters SimulatedAnnealingSearch()
        {
            Random rnd = new Random();

            // 1. Initialize Random State
            HyperParameters current = new HyperParameters
            {
                Epochs = rnd.Next(100, 2000),
                HiddenNeurons = rnd.Next(1, 10)
            };

            double currentCost = TrainAndEvaluate(current);

            HyperParameters best = current;
            double bestCost = currentCost;

            // Annealing Parameters
            double temperature = 1000.0;
            double coolingRate = 0.95; // Cools down by 5% every iteration
            double minTemp = 1.0;

            Console.WriteLine($"Initial State: {current} | Cost: {currentCost:F5}");

            while (temperature > minTemp)
            {
                // 2. Create a Neighbor (tweak current parameters slightly)
                HyperParameters neighbor = GetNeighbor(current, rnd);

                // 3. Calculate Cost (MSE) of Neighbor
                double neighborCost = TrainAndEvaluate(neighbor);

                // 4. Calculate Acceptance Probability
                // If neighbor is better (lower cost), prob is > 1, so we accept.
                // If neighbor is worse, we might still accept based on temperature.
                double costDiff = neighborCost - currentCost;
                double acceptanceProb = Math.Exp(-costDiff * 1000 / temperature); // Scaling factor for sensitivity

                // Decide whether to move to neighbor
                if (neighborCost < currentCost || rnd.NextDouble() < acceptanceProb)
                {
                    current = neighbor;
                    currentCost = neighborCost;

                    // Keep track of the absolute global best found so far
                    if (currentCost < bestCost)
                    {
                        best = current;
                        bestCost = currentCost;
                        Console.WriteLine($"New Global Best: {best} | Cost: {bestCost:F6} | Temp: {temperature:F1}");
                    }
                }

                // 5. Cool down
                temperature *= coolingRate;
            }

            return best;
        }

        // Helper to generate a "nearby" solution
        static HyperParameters GetNeighbor(HyperParameters p, Random rnd)
        {
            HyperParameters next = p;

            // 50% chance to change Epochs, 50% to change Neurons
            if (rnd.NextDouble() < 0.5)
            {
                // Change epochs by roughly +/- 100 to 500, kept within bounds
                int change = rnd.Next(-500, 500);
                next.Epochs = Clamp(next.Epochs + change, 100, 10000);
            }
            else
            {
                // Change neurons by +/- 1 or 2
                int change = rnd.Next(-2, 3);
                next.HiddenNeurons = Clamp(next.HiddenNeurons + change, 1, 20);
            }
            return next;
        }

        // A manual implementation of Clamp for older .NET versions
        static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        // --- THE FITNESS FUNCTION ---
        // Trains a network with specific params and returns the Mean Squared Error
        static double TrainAndEvaluate(HyperParameters p)
        {
            NeuralNet nn = new NeuralNet(4, p.HiddenNeurons, 1);

            // Train
            Train(nn, inputs, targets, p.Epochs);

            // Evaluate MSE
            double totalError = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                double output = Forward(nn, inputs[i]);
                double error = targets[i] - output;
                totalError += error * error;
            }
            return totalError / inputs.Length;
        }

    }
}