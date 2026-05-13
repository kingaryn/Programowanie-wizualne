using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ustawienia : Form
    {
        public ustawienia()
        {
            InitializeComponent();
        }

        private void ustawienia_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ustawieniagry.X = (int)kolumny.Value;
            ustawieniagry.Y = (int)wiersze.Value;
            ustawieniagry.Hyraxy = (int)ilehyrex.Value;
            ustawieniagry.Szopy = (int)ileszop.Value;
            ustawieniagry.Krokodyle = (int)ilekrokodyl.Value;
            ustawieniagry.Czas = (int)ileczas.Value;

            this.Close();
        }
    }
}
