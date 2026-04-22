namespace lab3
{
    public class Osoba
    {
        public string ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Wiek { get; set; }
        public string Stanowisko { get; set; }

        // Wymagany konstruktor bezparametrowy do XML
        public Osoba() { }

        public Osoba(string id, string imie, string nazwisko, string wiek, string stanowisko)
        {
            ID = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Stanowisko = stanowisko;
        }
    }
}