using System.Text;

namespace AnalizatorFasta;
public static class ParserFasta
{
    public static List<SekwencjaFasta> WczytajPlik(string sciezka)
    {
        var wynik = new List<SekwencjaFasta>();
        string? nazwa = null;
        string opis = "";
        var sekwencja = new StringBuilder();
        foreach (var liniaSurowa in File.ReadAllLines(sciezka))
        {
            var linia = liniaSurowa.Trim();
            if (linia == "")
                continue;
            if (linia.StartsWith(">"))
            {
                if (nazwa != null)
                {
                    DodajSekwencje();
                }
                var naglowek = linia.Substring(1);
                var czesci = naglowek.Split(' ', 2);
                nazwa = czesci[0];
                if (czesci.Length > 1)
                    opis = czesci[1];
                else
                    opis = "";
                sekwencja.Clear();
            }
            else 
            {
                if (nazwa == null) 
                {
                    throw new Exception("Plik nie jest poprawnym plikiem FASTA.");
                }
                sekwencja.Append(linia.ToUpper());
            }
        }
        if (nazwa != null) 
        {
            DodajSekwencje();
        }
        if (wynik.Count == 0)
        {
            throw new Exception("Nie znaleziono zadnej sekwencji FASTA.");
        }
        return wynik;
        void DodajSekwencje() 
        {
            if (sekwencja.Length == 0)
            {
                throw new Exception("Jedna z sekwencji nie ma danych.");
            }
            wynik.Add(new SekwencjaFasta
            {
                Nazwa = nazwa!,
                Opis = opis,
                Sekwencja = sekwencja.ToString(),
                PlikZrodlowy = Path.GetFileName(sciezka)
            });
        }
    }
}
