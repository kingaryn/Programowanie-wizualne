using System.Data;
using System.Windows.Forms;

namespace KomisApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }
        private void label14_Click(object sender, EventArgs e)
        {
        }
        private void label13_Click(object sender, EventArgs e)
        {
        }
        DatabaseManager db = new DatabaseManager();

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] data = new string[15]
            {
        textBox1.Text,
        textBox2.Text,
        textBox3.Text,
        textBox4.Text,
        textBox5.Text,
        textBox6.Text,
        textBox7.Text,
        textBox8.Text,
        textBox9.Text,
        textBox10.Text,
        textBox11.Text,
        textBox12.Text,
        textBox13.Text,
        textBox14.Text,
        textBox15.Text
            };

            db.WriteData(data);
            MessageBox.Show("Zapisano!");
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            var table = db.ReadData();

            // Wyœwietlimy w DataGridView (dodaj na formie)
            dataGridView1.DataSource = table;
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Entries", conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
    }
}
