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
        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            // Tworzenie nag³ówka pliku CSV
            string csvContent = "Column1,Column2,Column3" + Environment.NewLine;
            // Dodawanie danych z DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Pomijaj wiersze niemieszcz¹ce siê w DataGridView (np. wiersz zaznaczania)
                if (!row.IsNewRow)
                {
                    // Dodaj kolejne wartoœci w wierszu, oddzielone przecinkami
                    csvContent += string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>()
                    .ToArray(), c => c.Value)) + Environment.NewLine;
                }
            }
            // Zapisanie zawartoœci do pliku CSV
            File.WriteAllText(filePath, csvContent);
        }
        private void button3_Click(object sender, EventArgs e)
        {


            // Wyœwietlanie okna dialogowego wyboru lokalizacji zapisu
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.Title = "Wybierz lokalizacjê zapisu pliku CSV";
            saveFileDialog1.ShowDialog();
            // Jeœli u¿ytkownik wybierze lokalizacjê i zatwierdzi, zapisz plik CSV
            if (saveFileDialog1.FileName != "")
            {
                // U¿yj metody ExportToCSV i podaj obiekt DataGridView oraz œcie¿kê do pliku CSV
                ExportToCSV(dataGridView1, saveFileDialog1.FileName);
            }

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

