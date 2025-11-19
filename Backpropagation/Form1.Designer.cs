namespace Backpropagation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.outputNeuron = new System.Windows.Forms.Label();
            this.input1 = new System.Windows.Forms.CheckBox();
            this.input2 = new System.Windows.Forms.CheckBox();
            this.input3 = new System.Windows.Forms.CheckBox();
            this.input4 = new System.Windows.Forms.CheckBox();
            this.numberOfHN = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numberOfE = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.epoch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfHN)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfE)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Backpropagation.Properties.Resources.synapses;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(503, 280);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // outputNeuron
            // 
            this.outputNeuron.AutoSize = true;
            this.outputNeuron.Location = new System.Drawing.Point(82, 61);
            this.outputNeuron.Name = "outputNeuron";
            this.outputNeuron.Size = new System.Drawing.Size(36, 25);
            this.outputNeuron.TabIndex = 6;
            this.outputNeuron.Text = "....";
            this.outputNeuron.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // input1
            // 
            this.input1.AutoSize = true;
            this.input1.Location = new System.Drawing.Point(112, 228);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(62, 29);
            this.input1.TabIndex = 7;
            this.input1.Text = "x¹";
            this.input1.UseVisualStyleBackColor = true;
            // 
            // input2
            // 
            this.input2.AutoSize = true;
            this.input2.Location = new System.Drawing.Point(112, 308);
            this.input2.Name = "input2";
            this.input2.Size = new System.Drawing.Size(62, 29);
            this.input2.TabIndex = 8;
            this.input2.Text = "x²";
            this.input2.UseVisualStyleBackColor = true;
            // 
            // input3
            // 
            this.input3.AutoSize = true;
            this.input3.Location = new System.Drawing.Point(112, 389);
            this.input3.Name = "input3";
            this.input3.Size = new System.Drawing.Size(62, 29);
            this.input3.TabIndex = 9;
            this.input3.Text = "x³";
            this.input3.UseVisualStyleBackColor = true;
            // 
            // input4
            // 
            this.input4.AutoSize = true;
            this.input4.Location = new System.Drawing.Point(112, 475);
            this.input4.Name = "input4";
            this.input4.Size = new System.Drawing.Size(62, 29);
            this.input4.TabIndex = 10;
            this.input4.Text = "x⁴";
            this.input4.UseVisualStyleBackColor = true;
            // 
            // numberOfHN
            // 
            this.numberOfHN.Location = new System.Drawing.Point(44, 55);
            this.numberOfHN.Name = "numberOfHN";
            this.numberOfHN.Size = new System.Drawing.Size(120, 31);
            this.numberOfHN.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 658);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 67);
            this.button1.TabIndex = 12;
            this.button1.Text = "Train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(791, 658);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 67);
            this.button2.TabIndex = 13;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(112, 658);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 67);
            this.button3.TabIndex = 14;
            this.button3.Text = "Create Nerual Network";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Number of Neurons";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numberOfHN);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(477, 516);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.outputNeuron);
            this.panel2.Location = new System.Drawing.Point(809, 318);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Output";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numberOfE);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(791, 516);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 16;
            // 
            // numberOfE
            // 
            this.numberOfE.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numberOfE.Location = new System.Drawing.Point(39, 55);
            this.numberOfE.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numberOfE.Name = "numberOfE";
            this.numberOfE.Size = new System.Drawing.Size(120, 31);
            this.numberOfE.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Epochs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "Input Layer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "Hidden Layer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(836, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Output Layer";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.epoch);
            this.panel4.Location = new System.Drawing.Point(73, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 62);
            this.panel4.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Epoch:";
            // 
            // epoch
            // 
            this.epoch.AutoSize = true;
            this.epoch.Location = new System.Drawing.Point(138, 23);
            this.epoch.Name = "epoch";
            this.epoch.Size = new System.Drawing.Size(36, 25);
            this.epoch.TabIndex = 6;
            this.epoch.Text = "....";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 810);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.input4);
            this.Controls.Add(this.input3);
            this.Controls.Add(this.input2);
            this.Controls.Add(this.input1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfHN)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfE)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label outputNeuron;
        private System.Windows.Forms.CheckBox input1;
        private System.Windows.Forms.CheckBox input2;
        private System.Windows.Forms.CheckBox input3;
        private System.Windows.Forms.CheckBox input4;
        private System.Windows.Forms.NumericUpDown numberOfHN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown numberOfE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label epoch;
    }
}

