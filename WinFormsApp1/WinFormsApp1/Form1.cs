using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calculation;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        calculate cal = new calculate();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = cal.Add(int.Parse(textBox2.Text), int.Parse(textBox1.Text));
                textBox3.Text = i.ToString();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int i = cal.Sub(int.Parse(textBox2.Text), int.Parse(textBox1.Text));
                textBox3.Text = i.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
