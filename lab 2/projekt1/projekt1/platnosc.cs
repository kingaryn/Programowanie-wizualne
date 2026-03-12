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
        public platnosc()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var potwierdzenie = MessageBox.Show("Czy na pewno chcesz dokonać płatności?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Close();
        }
    }
}
