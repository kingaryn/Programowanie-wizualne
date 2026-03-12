namespace projekt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var wybierz = new wybierz();
            wybierz.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var transport = new transport();
            transport.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var platnosc = new platnosc();
            platnosc.Show();
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

        }
    }
}
