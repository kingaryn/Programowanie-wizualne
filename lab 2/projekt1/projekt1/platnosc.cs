using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt1
{
    public partial class platnosc : Form
    {
        public string WybranaPlatnosc { get; set; }
        public platnosc()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                WybranaPlatnosc = "Karta";
            else if (radioButton2.Checked)
                WybranaPlatnosc = "Przelew";
            else if (radioButton3.Checked)
                WybranaPlatnosc = "BLIK";
            else if (radioButton4.Checked)
                WybranaPlatnosc = "Płatność przy odbiorze";
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Wybierz metodę płatności!", "Błąd");
                return;
            }
            var potwierdzenie = MessageBox.Show(
                "Czy na pewno chcesz dokonać płatności?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (potwierdzenie == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
