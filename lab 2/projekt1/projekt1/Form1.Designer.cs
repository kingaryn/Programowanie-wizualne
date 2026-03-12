namespace projekt1
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
            lista = new ListView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // lista
            // 
            lista.Location = new Point(12, 12);
            lista.Name = "lista";
            lista.Size = new Size(315, 426);
            lista.TabIndex = 0;
            lista.UseCompatibleStateImageBehavior = false;
            lista.SelectedIndexChanged += lista_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(464, 213);
            button1.Name = "button1";
            button1.Size = new Size(276, 66);
            button1.TabIndex = 1;
            button1.Text = "Wybierz";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(464, 285);
            button2.Name = "button2";
            button2.Size = new Size(276, 66);
            button2.TabIndex = 2;
            button2.Text = "Transport";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(464, 357);
            button3.Name = "button3";
            button3.Size = new Size(276, 66);
            button3.TabIndex = 3;
            button3.Text = "Zapłać";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(464, 83);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(276, 27);
            textBox1.TabIndex = 4;
            textBox1.Text = "Cena";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lista);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lista;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
    }
}
