using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Dodawanie : Form
    {
        Form1 okno_glowne;
        public Dodawanie(Form1 okno)
        {
            InitializeComponent();
            this.okno_glowne = okno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            okno_glowne.dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
