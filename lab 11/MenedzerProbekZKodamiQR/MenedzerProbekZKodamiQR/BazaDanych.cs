using System.Data;
using Microsoft.Data.Sqlite;


public static class BazaDanych
{
    private static readonly string Polaczenie = "Data Source=probki.db";

    public static void InicjalizujBazeDanych()
    {
        using var polaczenie = new SqliteConnection(Polaczenie);
        polaczenie.Open();
        var komenda = polaczenie.CreateCommand();
        komenda.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Probki (
                Id TEXT PRIMARY KEY,
                Nazwa TEXT NOT NULL,
                Typ TEXT NOT NULL,
                DataPobrania TEXT NOT NULL,
                Opis TEXT
            );
            """;
        komenda.ExecuteNonQuery();
    }

    public static void DodajProbke(Probka probka)
    {
        using var polaczenie = new SqliteConnection(Polaczenie);
        polaczenie.Open();
        var komenda = polaczenie.CreateCommand();
        komenda.CommandText =
            """
            INSERT INTO Probki (Id, Nazwa, Typ, DataPobrania, Opis)
            VALUES ($id, $nazwa, $typ, $dataPobrania, $opis);
            """;
        komenda.Parameters.AddWithValue("$id", probka.Id);
        komenda.Parameters.AddWithValue("$nazwa", probka.Nazwa);
        komenda.Parameters.AddWithValue("$typ", probka.Typ);
        komenda.Parameters.AddWithValue("$dataPobrania", probka.DataPobrania.ToString("yyyy-MM-dd"));
        komenda.Parameters.AddWithValue("$opis", probka.Opis ?? "");
        komenda.ExecuteNonQuery();
    }
    public static void EdytujProbke(Probka probka)
    {
        using var polaczenie = new SqliteConnection(Polaczenie);
        polaczenie.Open();
        var komenda = polaczenie.CreateCommand();
        komenda.CommandText =
            """
            UPDATE Probki
            SET Nazwa = $nazwa, Typ = $typ, DataPobrania = $dataPobrania, Opis = $opis
            WHERE Id = $id;
            """;
        komenda.Parameters.AddWithValue("$id", probka.Id);
        komenda.Parameters.AddWithValue("$nazwa", probka.Nazwa);
        komenda.Parameters.AddWithValue("$typ", probka.Typ);
        komenda.Parameters.AddWithValue("$dataPobrania", probka.DataPobrania.ToString("yyyy-MM-dd"));
        komenda.Parameters.AddWithValue("$opis", probka.Opis ?? "");
        komenda.ExecuteNonQuery();
    }
    public static void UsunProbke(string idProbki)
    {
        using var polaczenie = new SqliteConnection(Polaczenie);
        polaczenie.Open();
        var komenda = polaczenie.CreateCommand();
        komenda.CommandText =
            """
            DELETE FROM Probki
            WHERE Id = $id;
            """;
        komenda.Parameters.AddWithValue("$id", idProbki);
        komenda.ExecuteNonQuery();
    }
    public static DataTable PobierzProbki(string szukanaFraza = "")
    {
        using var polaczenie = new SqliteConnection(Polaczenie);
        polaczenie.Open();
        var komenda = polaczenie.CreateCommand();
        if (string.IsNullOrWhiteSpace(szukanaFraza))
        {
            komenda.CommandText =
                """
            SELECT * FROM Probki
            ORDER BY DataPobrania DESC;
            """;
        }
        else
        {
            komenda.CommandText =
            """
            SELECT Id, Nazwa, Typ, DataPobrania, Opis
            FROM Probki
            WHERE Id LIKE $szukaj
               OR Nazwa LIKE $szukaj
               OR Typ LIKE $szukaj
               OR Opis LIKE $szukaj
            ORDER BY DataPobrania DESC;
            """;
            komenda.Parameters.AddWithValue("$szukaj", "%" + szukanaFraza+"%");
        }
        using var czytnik=komenda.ExecuteReader();
        var tabela = new DataTable();
        tabela.Load(czytnik);
        return tabela;
    }
}