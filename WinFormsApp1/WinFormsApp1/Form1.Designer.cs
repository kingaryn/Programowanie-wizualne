namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(394, 92);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(351, 27);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLight;
            button1.Location = new Point(586, 200);
            button1.Name = "button1";
            button1.Size = new Size(113, 40);
            button1.TabIndex = 2;
            button1.Text = "Subtraction";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlLight;
            button2.Location = new Point(448, 200);
            button2.Name = "button2";
            button2.Size = new Size(113, 40);
            button2.TabIndex = 3;
            button2.Text = "Addition";
            button2.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(394, 158);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(351, 27);
            textBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(264, 99);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 5;
            label1.Text = "First number";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(264, 165);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 6;
            label2.Text = "Second number";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
    }
}
