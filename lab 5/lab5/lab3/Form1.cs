using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Serialization;
using System.Text.Json;
namespace lab3
{
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
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Imie", "Imiê");
            dataGridView1.Columns.Add("Nazwisko", "Nazwisko");
            dataGridView1.Columns.Add("Wiek", "Wiek");
            dataGridView1.Columns.Add("Stanowisko", "Stanowisko");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            string csvContent = "ID,Imie,Nazwisko,Wiek,Stanowisko" + Environment.NewLine;
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
            {
                int index = dataGridView1.SelectedRows[0].Index;

                var wynik = MessageBox.Show(
                    "Czy na pewno chcesz usun¹æ zaznaczony wiersz?",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (wynik == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(index);
                }
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz do usuniêcia!");
            }
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
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                dataGridView1.Rows.Add(values);
            }
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
        private List<Osoba> PobierzOsobyZGrid()
        {
            List<Osoba> osoby = new List<Osoba>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                osoby.Add(new Osoba(
                    row.Cells["ID"].Value?.ToString(),
                    row.Cells["Imie"].Value?.ToString(),
                    row.Cells["Nazwisko"].Value?.ToString(),
                    row.Cells["Wiek"].Value?.ToString(),
                    row.Cells["Stanowisko"].Value?.ToString()
                ));
            }

            return osoby;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Plik XML (*.xml)|*.xml";
            sfd.Title = "Zapisz dane jako XML";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<Osoba> osoby = PobierzOsobyZGrid();

                XmlSerializer serializer = new XmlSerializer(typeof(List<Osoba>));
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    serializer.Serialize(fs, osoby);
                }

                MessageBox.Show("Dane zapisano do XML.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Plik JSON (*.json)|*.json";
            sfd.Title = "Zapisz dane jako JSON";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<Osoba> osoby = PobierzOsobyZGrid();

                string json = JsonSerializer.Serialize(osoby,
                    new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(sfd.FileName, json);

                MessageBox.Show("Dane zapisano do JSON.");
            }
        }
    }
}

