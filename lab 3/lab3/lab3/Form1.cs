using System.Diagnostics.Eventing.Reader;

namespace lab3
{//Dodaæ zapisywanie do pliku, odczytywanie z pliku, usuwanie wiersza i jakieœ bezpieczeñstwa
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dodawanie okno = new Dodawanie(this);
            okno.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                //sposób julki coœ z nim pokombinowaæ
                //int index = dataGridView1.SelectedRows[0].Index;
                //dataGridView1.Rows.RemoveAt(index);
                MessageBox.Show("Dokoñczyæ");
            else
                MessageBox.Show("Nie mo¿na usun¹æ pustego wiersza");
        }
    }
}
