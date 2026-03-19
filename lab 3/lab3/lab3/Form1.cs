using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace lab3
{//Dodaæ usuwanie wiersza i jakieœ bezpieczeñstwa
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
            string csvContent = "Column1,Column2,Column3" + Environment.NewLine;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    csvContent += string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>()
                    .ToArray(), c => c.Value)) + Environment.NewLine;
                }
            }
            File.WriteAllText(filePath, csvContent);
        }
        private void button3_Click(object sender, EventArgs e)
        {


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            saveFileDialog1.Title = "Wybierz lokalizacjê zapisu pliku CSV";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
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
        private void LoadCSVToDataGridView(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] lines = File.ReadAllLines(filePath);
            DataTable dataTable = new DataTable();
            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                dataTable.Rows.Add(values);
            }
            dataGridView1.DataSource = dataTable;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
            openFileDialog1.Title = "Wybierz plik CSV do wczytania";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                LoadCSVToDataGridView(openFileDialog1.FileName);
            }
        }
    }
}

