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
    public partial class wybierz : Form
    {
        public string wybranyProdukt;
        public string wybranaCena;
        public wybierz()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("Produkt", 120);
            listView1.Columns.Add("Cena", 80);

            listView1.Items.Add(new ListViewItem(new[] { "Pizza", "20" }));
            listView1.Items.Add(new ListViewItem(new[] { "Burger", "15" }));
            listView1.Items.Add(new ListViewItem(new[] { "Kebab", "18" }));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];

                wybranyProdukt = item.SubItems[0].Text;
                wybranaCena = item.SubItems[1].Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Wybierz produkt!");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
