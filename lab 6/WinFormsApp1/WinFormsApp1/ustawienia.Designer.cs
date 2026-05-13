namespace WinFormsApp1
{
    partial class ustawienia
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            kolumny = new NumericUpDown();
            wiersze = new NumericUpDown();
            ilehyrex = new NumericUpDown();
            ileszop = new NumericUpDown();
            ileczas = new NumericUpDown();
            label7 = new Label();
            ilekrokodyl = new NumericUpDown();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)kolumny).BeginInit();
            ((System.ComponentModel.ISupportInitialize)wiersze).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ilehyrex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ileszop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ileczas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ilekrokodyl).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 27);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Plansza";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 60);
            label2.Name = "label2";
            label2.Size = new Size(18, 20);
            label2.TabIndex = 1;
            label2.Text = "X";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 114);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 2;
            label3.Text = "Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(357, 27);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 3;
            label4.Text = "Hyraxy";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(362, 94);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 4;
            label5.Text = "Szopy";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(167, 288);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 5;
            label6.Text = "Czas";
            // 
            // kolumny
            // 
            kolumny.Location = new Point(56, 58);
            kolumny.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            kolumny.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            kolumny.Name = "kolumny";
            kolumny.Size = new Size(150, 27);
            kolumny.TabIndex = 6;
            kolumny.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // wiersze
            // 
            wiersze.Location = new Point(56, 114);
            wiersze.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            wiersze.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            wiersze.Name = "wiersze";
            wiersze.Size = new Size(150, 27);
            wiersze.TabIndex = 7;
            wiersze.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // ilehyrex
            // 
            ilehyrex.Location = new Point(309, 58);
            ilehyrex.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            ilehyrex.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ilehyrex.Name = "ilehyrex";
            ilehyrex.Size = new Size(150, 27);
            ilehyrex.TabIndex = 8;
            ilehyrex.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ileszop
            // 
            ileszop.Location = new Point(309, 117);
            ileszop.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            ileszop.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            ileszop.Name = "ileszop";
            ileszop.Size = new Size(150, 27);
            ileszop.TabIndex = 9;
            ileszop.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // ileczas
            // 
            ileczas.Location = new Point(273, 286);
            ileczas.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            ileczas.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            ileczas.Name = "ileczas";
            ileczas.Size = new Size(150, 27);
            ileczas.TabIndex = 10;
            ileczas.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(347, 157);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 11;
            label7.Text = "Krokodyle";
            // 
            // ilekrokodyl
            // 
            ilekrokodyl.Location = new Point(309, 180);
            ilekrokodyl.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            ilekrokodyl.Name = "ilekrokodyl";
            ilekrokodyl.Size = new Size(150, 27);
            ilekrokodyl.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(147, 366);
            button1.Name = "button1";
            button1.Size = new Size(183, 42);
            button1.TabIndex = 13;
            button1.Text = "Zapisz";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ustawienia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 450);
            Controls.Add(button1);
            Controls.Add(ilekrokodyl);
            Controls.Add(label7);
            Controls.Add(ileczas);
            Controls.Add(ileszop);
            Controls.Add(ilehyrex);
            Controls.Add(wiersze);
            Controls.Add(kolumny);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ustawienia";
            Text = "ustawienia";
            Load += ustawienia_Load;
            ((System.ComponentModel.ISupportInitialize)kolumny).EndInit();
            ((System.ComponentModel.ISupportInitialize)wiersze).EndInit();
            ((System.ComponentModel.ISupportInitialize)ilehyrex).EndInit();
            ((System.ComponentModel.ISupportInitialize)ileszop).EndInit();
            ((System.ComponentModel.ISupportInitialize)ileczas).EndInit();
            ((System.ComponentModel.ISupportInitialize)ilekrokodyl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown kolumny;
        private NumericUpDown wiersze;
        private NumericUpDown ilehyrex;
        private NumericUpDown ileszop;
        private NumericUpDown ileczas;
        private Label label7;
        private NumericUpDown ilekrokodyl;
        private Button button1;
    }
}