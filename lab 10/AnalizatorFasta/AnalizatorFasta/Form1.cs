using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace AnalizatorFasta;

public partial class Form1 : Form
{
    private Button przyciskWczytaj = new Button();
    private Button przyciskCsv = new Button();
    private Button przyciskJson = new Button();

    private ListBox listaSekwencji = new ListBox();
    private TextBox poleSzczegoly = new TextBox();
    private Panel panelWykresu = new Panel();

    private List<SekwencjaFasta> sekwencje = new List<SekwencjaFasta>();

    public Form1()
    {
        Text = "Analizator FASTA";
        Width = 1000;
        Height = 700;
        StartPosition = FormStartPosition.CenterScreen;
        StworzInterfejs();

    }
    private void StworzInterfejs() 
    {
        przyciskWczytaj.Text = "Wczytaj FASTA";
        przyciskWczytaj.Left = 20;
        przyciskWczytaj.Top = 20;
        przyciskWczytaj.Width=130;
        przyciskWczytaj.Click += PrzyciskWczytaj_Click;
        Controls.Add(przyciskWczytaj);
        
        przyciskCsv.Text = "EksportCSV";
        przyciskCsv.Left =170; 
        przyciskCsv.Top = 20;
        przyciskCsv.Width = 120;
        przyciskCsv.Click += PrzyciskCsv_Click;
        Controls.Add(przyciskCsv);

        przyciskJson.Text = "Eksport JSON";
        przyciskJson.Left = 310;
        przyciskJson.Top = 20;
        przyciskJson.Width = 120;
        przyciskJson.Click += PrzyciskJson_Click;
        Controls.Add(przyciskJson);

        listaSekwencji.Left = 20;
        listaSekwencji.Top = 70;
        listaSekwencji.Width = 380;
        listaSekwencji.Height = 550;
        listaSekwencji.SelectedIndexChanged += ListaSekwencji_SelectedIndexChanged;
        Controls.Add(listaSekwencji);

        poleSzczegoly.Left = 420;
        poleSzczegoly.Top = 70;
        poleSzczegoly.Width = 530;
        poleSzczegoly.Height = 260;
        poleSzczegoly.Multiline = true;
        poleSzczegoly.ScrollBars = ScrollBars.Vertical;
        poleSzczegoly.ReadOnly = true;
        poleSzczegoly.Font = new Font("Consolas", 10);
        Controls.Add(poleSzczegoly);

        panelWykresu.Left = 420;
        panelWykresu.Top = 350;
        panelWykresu.Width = 530;
        panelWykresu.Height = 270;
        panelWykresu.BorderStyle = BorderStyle.FixedSingle;
        panelWykresu.Paint += PanelWykresu_Paint;
        Controls.Add(panelWykresu);
    }
    private void PrzyciskWczytaj_Click(object? sender, EventArgs e)
    {
        OpenFileDialog okno = new OpenFileDialog();
        okno.Title = "Wybierz pliki FASTA";
        okno.Filter = "Pliki FASTA|*.fasta;*.fa;*.txt|Wszystkie pliki|*.*";
        okno.Multiselect = true;

        if (okno.ShowDialog() == DialogResult.OK)
        {
            try
            {
                sekwencje.Clear();

                foreach (var plik in okno.FileNames)
                {
                    var wczytane = ParserFasta.WczytajPlik(plik);
                    sekwencje.AddRange(wczytane);
                }

                OdswiezListe();
                panelWykresu.Invalidate();

                MessageBox.Show("Wczytano sekwencje: " + sekwencje.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d: " + ex.Message);
            }
        }
    }
    private void OdswiezListe()
    {
        listaSekwencji.Items.Clear();

        foreach (var s in sekwencje)
        {
            listaSekwencji.Items.Add($"{s.Nazwa} | d³ugoœæ: {s.Dlugosc}");
        }
    }

    private void ListaSekwencji_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (listaSekwencji.SelectedIndex < 0)
            return;

        var s = sekwencje[listaSekwencji.SelectedIndex];

        poleSzczegoly.Text =
            $"Nazwa: {s.Nazwa}" + Environment.NewLine +
            $"Opis: {s.Opis}" + Environment.NewLine +
            $"Plik: {s.PlikZrodlowy}" + Environment.NewLine +
            $"D³ugoœæ: {s.Dlugosc}" + Environment.NewLine +
            $"Zawartoœæ GC: {s.ZawartoscGC:0.00}%" + Environment.NewLine +
            $"Liczba kodonów: {s.LiczbaKodonow}" + Environment.NewLine +
            $"A: {s.LiczbaA}" + Environment.NewLine +
            $"T: {s.LiczbaT}" + Environment.NewLine +
            $"G: {s.LiczbaG}" + Environment.NewLine +
            $"C: {s.LiczbaC}" + Environment.NewLine +
            $"Inne znaki: {s.InneZnaki}" + Environment.NewLine +
            Environment.NewLine +
            "Sekwencja:" + Environment.NewLine +
            PodzielTekst(s.Sekwencja, 70);
    }

    private void PrzyciskCsv_Click(object? sender, EventArgs e)
    {
        if (sekwencje.Count == 0)
        {
            MessageBox.Show("Najpierw wczytaj plik FASTA.");
            return;
        }

        SaveFileDialog okno = new SaveFileDialog();
        okno.Filter = "CSV|*.csv";
        okno.FileName = "wyniki.csv";

        if (okno.ShowDialog() == DialogResult.OK)
        {
            ZapiszCsv(okno.FileName);
            MessageBox.Show("Zapisano CSV.");
        }
    }

    private void PrzyciskJson_Click(object? sender, EventArgs e)
    {
        if (sekwencje.Count == 0)
        {
            MessageBox.Show("Najpierw wczytaj plik FASTA.");
            return;
        }

        SaveFileDialog okno = new SaveFileDialog();
        okno.Filter = "JSON|*.json";
        okno.FileName = "wyniki.json";

        if (okno.ShowDialog() == DialogResult.OK)
        {
            ZapiszJson(okno.FileName);
            MessageBox.Show("Zapisano JSON.");
        }
    }

    private void ZapiszCsv(string sciezka)
    {
        var tekst = new StringBuilder();

        tekst.AppendLine("Nazwa;Opis;Plik;Dlugosc;GC;Kodony;A;T;G;C;Inne");

        foreach (var s in sekwencje)
        {
            tekst.AppendLine(
                $"{s.Nazwa};{s.Opis};{s.PlikZrodlowy};{s.Dlugosc};{s.ZawartoscGC:0.00};{s.LiczbaKodonow};{s.LiczbaA};{s.LiczbaT};{s.LiczbaG};{s.LiczbaC};{s.InneZnaki}"
            );
        }

        File.WriteAllText(sciezka, tekst.ToString(), Encoding.UTF8);
    }

    private void ZapiszJson(string sciezka)
    {
        var opcje = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(sekwencje, opcje);
        File.WriteAllText(sciezka, json, Encoding.UTF8);
    }

    private void PanelWykresu_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.White);

        if (sekwencje.Count == 0)
        {
            g.DrawString("Brak danych do wykresu", Font, Brushes.Black, 20, 20);
            return;
        }

        int marginesLewy = 50;
        int marginesDolny = 40;
        int wysokosc = panelWykresu.Height - 70;
        int szerokosc = panelWykresu.Width - 80;

        int maxDlugosc = sekwencje.Max(s => s.Dlugosc);

        if (maxDlugosc == 0)
            return;

        g.DrawLine(Pens.Black, marginesLewy, 20, marginesLewy, 20 + wysokosc);
        g.DrawLine(Pens.Black, marginesLewy, 20 + wysokosc, marginesLewy + szerokosc, 20 + wysokosc);

        int liczba = sekwencje.Count;
        int szerokoscSlupka = Math.Max(10, szerokosc / liczba - 10);

        for (int i = 0; i < liczba; i++)
        {
            var s = sekwencje[i];

            int x = marginesLewy + 10 + i * (szerokosc / liczba);
            int h = (int)(s.Dlugosc / (double)maxDlugosc * wysokosc);
            int y = 20 + wysokosc - h;

            g.FillRectangle(Brushes.SteelBlue, x, y, szerokoscSlupka, h);
            g.DrawRectangle(Pens.Black, x, y, szerokoscSlupka, h);

            g.DrawString(s.Nazwa, new Font("Arial", 8), Brushes.Black, x, 25 + wysokosc);
        }

        g.DrawString("Wykres d³ugoœci sekwencji", Font, Brushes.Black, 160, 5);
    }

    private string PodzielTekst(string tekst, int dlugoscLinii)
    {
        var wynik = new StringBuilder();

        for (int i = 0; i < tekst.Length; i += dlugoscLinii)
        {
            int ile = Math.Min(dlugoscLinii, tekst.Length - i);
            wynik.AppendLine(tekst.Substring(i, ile));
        }

        return wynik.ToString();
    }
    private void Form1_Load(object sender, EventArgs e)
    {

    }
}
