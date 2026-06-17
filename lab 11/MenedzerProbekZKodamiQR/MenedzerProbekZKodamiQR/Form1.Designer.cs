namespace MenedzerProbekZKodamiQR
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
            txtIdProbki = new TextBox();
            txtNazwaProbki = new TextBox();
            txtOpis = new TextBox();
            txtSzukaj = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbTypProbki = new ComboBox();
            dtpDataPobrania = new DateTimePicker();
            btnDodaj = new Button();
            btnEdytuj = new Button();
            btnUsun = new Button();
            label6 = new Label();
            btnSzukaj = new Button();
            tabelaProbek = new DataGridView();
            label7 = new Label();
            obrazQr = new PictureBox();
            btnGenerujQr = new Button();
            btnEksportujPng = new Button();
            btnDrukuj = new Button();
            ((System.ComponentModel.ISupportInitialize)tabelaProbek).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obrazQr).BeginInit();
            SuspendLayout();
            // 
            // txtIdProbki
            // 
            txtIdProbki.Location = new Point(313, 28);
            txtIdProbki.Name = "txtIdProbki";
            txtIdProbki.Size = new Size(125, 27);
            txtIdProbki.TabIndex = 0;
            // 
            // txtNazwaProbki
            // 
            txtNazwaProbki.Location = new Point(313, 61);
            txtNazwaProbki.Name = "txtNazwaProbki";
            txtNazwaProbki.Size = new Size(125, 27);
            txtNazwaProbki.TabIndex = 1;
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(313, 161);
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(125, 27);
            txtOpis.TabIndex = 2;
            // 
            // txtSzukaj
            // 
            txtSzukaj.Location = new Point(168, 252);
            txtSzukaj.Name = "txtSzukaj";
            txtSzukaj.Size = new Size(125, 27);
            txtSzukaj.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 31);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 4;
            label1.Text = "Id probki:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 61);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 5;
            label2.Text = "Nazwa probki:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 96);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 6;
            label3.Text = "Typ probki:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 134);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 7;
            label4.Text = "Data pobrania:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 168);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 8;
            label5.Text = "Opis/uwagi:";
            // 
            // cmbTypProbki
            // 
            cmbTypProbki.FormattingEnabled = true;
            cmbTypProbki.Items.AddRange(new object[] { "DNA", "RNA", "Bialko", "Inny" });
            cmbTypProbki.Location = new Point(313, 93);
            cmbTypProbki.Name = "cmbTypProbki";
            cmbTypProbki.Size = new Size(151, 28);
            cmbTypProbki.TabIndex = 9;
            // 
            // dtpDataPobrania
            // 
            dtpDataPobrania.Location = new Point(313, 127);
            dtpDataPobrania.Name = "dtpDataPobrania";
            dtpDataPobrania.Size = new Size(250, 27);
            dtpDataPobrania.TabIndex = 10;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(44, 205);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(94, 29);
            btnDodaj.TabIndex = 11;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnEdytuj
            // 
            btnEdytuj.Location = new Point(199, 205);
            btnEdytuj.Name = "btnEdytuj";
            btnEdytuj.Size = new Size(94, 29);
            btnEdytuj.TabIndex = 12;
            btnEdytuj.Text = "Edytuj";
            btnEdytuj.UseVisualStyleBackColor = true;
            // 
            // btnUsun
            // 
            btnUsun.Location = new Point(344, 205);
            btnUsun.Name = "btnUsun";
            btnUsun.Size = new Size(94, 29);
            btnUsun.TabIndex = 13;
            btnUsun.Text = "Usun";
            btnUsun.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(44, 255);
            label6.Name = "label6";
            label6.Size = new Size(124, 20);
            label6.TabIndex = 14;
            label6.Text = "Wyszukaj probke:";
            // 
            // btnSzukaj
            // 
            btnSzukaj.Location = new Point(344, 252);
            btnSzukaj.Name = "btnSzukaj";
            btnSzukaj.Size = new Size(94, 29);
            btnSzukaj.TabIndex = 15;
            btnSzukaj.Text = "Szukaj";
            btnSzukaj.UseVisualStyleBackColor = true;
            // 
            // tabelaProbek
            // 
            tabelaProbek.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaProbek.Location = new Point(44, 287);
            tabelaProbek.Name = "tabelaProbek";
            tabelaProbek.RowHeadersWidth = 51;
            tabelaProbek.Size = new Size(300, 188);
            tabelaProbek.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 506);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 17;
            label7.Text = "Kod QR:";
            // 
            // obrazQr
            // 
            obrazQr.Location = new Point(44, 543);
            obrazQr.Name = "obrazQr";
            obrazQr.Size = new Size(331, 161);
            obrazQr.TabIndex = 18;
            obrazQr.TabStop = false;
            // 
            // btnGenerujQr
            // 
            btnGenerujQr.Location = new Point(59, 752);
            btnGenerujQr.Name = "btnGenerujQr";
            btnGenerujQr.Size = new Size(94, 29);
            btnGenerujQr.TabIndex = 19;
            btnGenerujQr.Text = "Generuj QR";
            btnGenerujQr.UseVisualStyleBackColor = true;
            // 
            // btnEksportujPng
            // 
            btnEksportujPng.Location = new Point(180, 751);
            btnEksportujPng.Name = "btnEksportujPng";
            btnEksportujPng.Size = new Size(119, 29);
            btnEksportujPng.TabIndex = 20;
            btnEksportujPng.Text = "Eksportuj PNG";
            btnEksportujPng.UseVisualStyleBackColor = true;
            // 
            // btnDrukuj
            // 
            btnDrukuj.Location = new Point(329, 751);
            btnDrukuj.Name = "btnDrukuj";
            btnDrukuj.Size = new Size(163, 29);
            btnDrukuj.TabIndex = 21;
            btnDrukuj.Text = "Drukuj etykiete";
            btnDrukuj.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 792);
            Controls.Add(btnDrukuj);
            Controls.Add(btnEksportujPng);
            Controls.Add(btnGenerujQr);
            Controls.Add(obrazQr);
            Controls.Add(label7);
            Controls.Add(tabelaProbek);
            Controls.Add(btnSzukaj);
            Controls.Add(label6);
            Controls.Add(btnUsun);
            Controls.Add(btnEdytuj);
            Controls.Add(btnDodaj);
            Controls.Add(dtpDataPobrania);
            Controls.Add(cmbTypProbki);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSzukaj);
            Controls.Add(txtOpis);
            Controls.Add(txtNazwaProbki);
            Controls.Add(txtIdProbki);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)tabelaProbek).EndInit();
            ((System.ComponentModel.ISupportInitialize)obrazQr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdProbki;
        private TextBox txtNazwaProbki;
        private TextBox txtOpis;
        private TextBox txtSzukaj;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbTypProbki;
        private DateTimePicker dtpDataPobrania;
        private Button btnDodaj;
        private Button btnEdytuj;
        private Button btnUsun;
        private Label label6;
        private Button btnSzukaj;
        private DataGridView tabelaProbek;
        private Label label7;
        private PictureBox obrazQr;
        private Button btnGenerujQr;
        private Button btnEksportujPng;
        private Button btnDrukuj;
    }
}
