using QRCoder;
using System.Drawing;
using System.Drawing.Printing;
namespace MenedzerProbekZKodamiQR
{
    public partial class Form1 : Form
    {
        private PrintDocument dokumentDoDruku = new PrintDocument();
        public Form1()
        {
            InitializeComponent();

            cmbTypProbki.Items.AddRange(new string[] { "DNA", "RNA", "Bialko", "Inny" });
            cmbTypProbki.SelectedIndex = 0;
            BazaDanych.Inicjalizuj();
            ZaladujProbki();
            dokumentDoDruku.PrintPage += DokumentDoDruku_PrintPage;
        }
        private void ZaladujProbki()
        {
            tabelaProbek.DataSource = BazaDanych.PobierzProbki(txtSzukaj.Text);
        }
        private Probka PobierzProbkeZFormularza()
        {
            return new Probka
            {
                Id = txtIdProbki.Text,
                Nazwa = txtNazwaProbki.Text,
                Typ = cmbTypProbki.Text,
                DataPobrania = dtpDataPobrania.Value,
                Opis = txtOpis.Text
            };
        }
        private void WyczyscFormularz()
        {
            txtIdProbki.Clear();
            txtNazwaProbki.Clear();
            txtOpis.Clear();
            cmbTypProbki.SelectedIndex = 0;
            dtpDataPobrania.Value = DateTime.Now;
            obrazQr.Image = null;
        }
        private void DokumentDoDruku_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (obrazQr.Image == null)
            {
                return;
            }
            Font czcionkaTytul = new Font("Arial", 16, FontStyle.Bold);
            Font czcionkaNormalna = new Font("Arial", 10);

            Brush pedzel = Brushes.Black;

            e.Graphics.DrawString("Etykieta probki biologicznej", czcionkaTytul, pedzel, new PointF(50, 30));
            e.Graphics.DrawString($"Nazwa: {txtNazwaProbki.Text}", czcionkaNormalna, pedzel, new PointF(50, 95));
            e.Graphics.DrawString($"Typ: {cmbTypProbki.Text}", czcionkaNormalna, pedzel, new PointF(50, 120));
            e.Graphics.DrawString($"Data pobrania: {dtpDataPobrania.Value:yyyy-MM-dd}", czcionkaNormalna, pedzel, new PointF(50, 145));

            e.Graphics.DrawImage(obrazQr.Image, 50, 180, 220, 220);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProbki.Text) ||
                string.IsNullOrWhiteSpace(txtNazwaProbki.Text))
            {
                MessageBox.Show("Id i nazwa próbki s¹ wymagane.");
                return;
            }
            Probka probka = PobierzProbkeZFormularza();
            try
            {
                BazaDanych.DodajProbke(probka);
                ZaladujProbki();
                WyczyscFormularz();
            }
            catch
            {
                MessageBox.Show("Nie udalo sie dodac probki. Sprawdz, czy ID probki jest unikalne.");
            }
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProbki.Text))
            {
                MessageBox.Show("Wybierz probke do edycji.");
                return;
            }
            Probka probka = PobierzProbkeZFormularza();
            BazaDanych.EdytujProbke(probka);
            ZaladujProbki();
            MessageBox.Show("Zaktualizowano probke.");
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProbki.Text))
            {
                MessageBox.Show("Najpierw wybierz próbkê do usuniêcia.");
                return;
            }

            DialogResult wynik = MessageBox.Show(
                "Czy na pewno chcesz usun¹æ tê próbkê?",
                "Potwierdzenie usuniêcia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (wynik == DialogResult.Yes)
            {
                BazaDanych.UsunProbke(txtIdProbki.Text);
                ZaladujProbki();
                WyczyscFormularz();

                MessageBox.Show("Usuniêto próbkê.");
            }
        }

        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            ZaladujProbki();
        }

        private void tabelaProbek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow wiersz = tabelaProbek.Rows[e.RowIndex];

            txtIdProbki.Text = wiersz.Cells["Id"].Value.ToString();
            txtNazwaProbki.Text = wiersz.Cells["Nazwa"].Value.ToString();
            cmbTypProbki.Text = wiersz.Cells["Typ"].Value.ToString();
            dtpDataPobrania.Value = DateTime.Parse(wiersz.Cells["DataPobrania"].Value.ToString());
            txtOpis.Text = wiersz.Cells["Opis"].Value.ToString();
        }

        private void txtSzukaj_TextChanged(object sender, EventArgs e)
        {
            ZaladujProbki();
        }
        private string PrzygotujTekstDoQr()
        {
            return
                $"ID probki: {txtIdProbki.Text}\n" +
                $"Nazwa: {txtNazwaProbki.Text}\n" +
                $"Typ: {cmbTypProbki.Text}\n" +
                $"Data pobrania: {dtpDataPobrania.Value:yyyy-MM-dd}\n" +
                $"Opis: {txtOpis.Text}";
        }

        private void btnGenerujQr_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProbki.Text) ||
                string.IsNullOrWhiteSpace(txtNazwaProbki.Text))
            {
                MessageBox.Show("Id i nazwa próbki s¹ wymagane do wygenerowania kodu QR.");
                return;
            }
            string tekstDoQr = PrzygotujTekstDoQr();
            QRCodeGenerator generatorQr = new QRCodeGenerator();
            QRCodeData daneQr = generatorQr.CreateQrCode(tekstDoQr, QRCodeGenerator.ECCLevel.Q);
            QRCode kodQr = new QRCode(daneQr);
            Bitmap obrazKoduQr = kodQr.GetGraphic(20);
            obrazQr.Image = obrazKoduQr;
        }

        private void btnEksportujPng_Click(object sender, EventArgs e)
        {
            if (obrazQr.Image == null)
            {
                MessageBox.Show("Najpierw wygeneruj kod QR.");
                return;
            }
            using SaveFileDialog oknoZapisu = new SaveFileDialog();
            oknoZapisu.Filter= "Pliki PNG|*.png";
            oknoZapisu.FileName=$"{txtIdProbki.Text}_qr.png";
            if (oknoZapisu.ShowDialog() == DialogResult.OK)
            {
                obrazQr.Image.Save(oknoZapisu.FileName, System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("Kod QR zosta³ zapisany jako plik PNG.");
            }
        }

        private void btnDrukuj_Click(object sender, EventArgs e)
        {
            if(obrazQr.Image == null)
            {
                MessageBox.Show("Najpierw wygeneruj kod QR.");
                return;
            }
            using PrintPreviewDialog podgladDruku = new PrintPreviewDialog();
            podgladDruku.Document = dokumentDoDruku;
            podgladDruku.ShowDialog();
        }
    }
}
