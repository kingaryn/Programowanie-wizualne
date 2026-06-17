namespace AnalizatorFasta;
public class SekwencjaFasta
{
    public string Nazwa { get; set; } = "";
    public string Opis { get; set; } = "";
    public string Sekwencja { get; set; } = "";
    public string PlikZrodlowy { get; set; } = "";

    public int Dlugosc => Sekwencja.Length;
    public int LiczbaA => Sekwencja.Count(x => x == 'A');
    public int LiczbaT => Sekwencja.Count(x => x == 'T');
    public int LiczbaG => Sekwencja.Count(x => x == 'G');
    public int LiczbaC => Sekwencja.Count(x => x == 'C');

    public int InneZnaki => Dlugosc - LiczbaA - LiczbaT - LiczbaG - LiczbaC;
    public int LiczbaKodonow => Dlugosc / 3;
    public double ZawartoscGC 
    {
        get
        {
            if (Dlugosc == 0)
                return 0;
            return (LiczbaG + LiczbaC) * 100.0 / Dlugosc;
        }
    
    }

}
