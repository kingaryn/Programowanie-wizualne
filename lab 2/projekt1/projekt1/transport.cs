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
    public partial class transport : Form
    {
        public event Action<string> TransportWybrany;
        public transport()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string transport = "";

            if (checkBox1.Checked)
                transport = "Odbiór osobisty";
            else if (checkBox2.Checked)
                transport = "Kurier";
            else if (checkBox3.Checked)
                transport = "Paczkomat";
            else if (checkBox4.Checked)
                transport = "Poczta";

            if (transport == "")
            {
                MessageBox.Show("Nie wybrano transportu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TransportWybrany?.Invoke(transport);

            MessageBox.Show("Wybrano: " + transport);

            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void transport_Load(object sender, EventArgs e)
        {

        }
    }
}
