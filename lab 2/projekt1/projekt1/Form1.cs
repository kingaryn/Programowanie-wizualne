namespace projekt1
{
    public partial class Form1 : Form
    {
        int suma = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wybierz = new wybierz();

            if (wybierz.ShowDialog() == DialogResult.OK)
            {
                lista.Items.Add(new ListViewItem(new[]
                {
                    wybierz.wybranyProdukt,
                    wybierz.wybranaCena
                }));

                suma += int.Parse(wybierz.wybranaCena);

                label1.Text = "Suma: " + suma + " z³";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var transport = new transport();

            transport.TransportWybrany += (wybranyTransport) =>
            {
                MessageBox.Show("Transport: " + wybranyTransport);
            };

            transport.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var platnosc = new platnosc();
            if (platnosc.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Wybrana p³atnoœæ: " + platnosc.WybranaPlatnosc);
            }
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lista.View = View.Details;
            lista.Columns.Add("Produkt", 120);
            lista.Columns.Add("Cena", 80);
        }
    }
}
