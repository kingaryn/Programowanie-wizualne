using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;

namespace lab9;

public class DatabaseManager
{
    private readonly string connectionString;

    public DatabaseManager()
    {
        string dbPath = Path.Combine(AppContext.BaseDirectory, "formularze.db");
        connectionString = $"Data Source={dbPath}";
        CreateTable();
    }

    private void CreateTable()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string query = """
        CREATE TABLE IF NOT EXISTS Formularze (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            ImieNazwisko TEXT,
            NumerAlbumu TEXT,
            Kierunek TEXT,
            Stopien TEXT,
            Semestr TEXT,
            TrybStudiow TEXT,
            RokAkademicki TEXT,
            Przedmiot TEXT,
            Prowadzacy TEXT,
            TerminEgzaminu TEXT,
            Uzasadnienie TEXT,
            DataZlozenia TEXT,
            AdresEmail TEXT,
            Telefon TEXT,
            Podpis TEXT
        );
        """;

        using var command = new SqliteCommand(query, connection);
        command.ExecuteNonQuery();
    }

    public void WriteData(
        string imieNazwisko,
        string numerAlbumu,
        string kierunek,
        string stopien,
        string semestr,
        string trybStudiow,
        string rokAkademicki,
        string przedmiot,
        string prowadzacy,
        string terminEgzaminu,
        string uzasadnienie,
        string dataZlozenia,
        string adresEmail,
        string telefon,
        string podpis)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string query = """
        INSERT INTO Formularze 
        (
            ImieNazwisko, NumerAlbumu, Kierunek, Stopien, Semestr,
            TrybStudiow, RokAkademicki, Przedmiot, Prowadzacy,
            TerminEgzaminu, Uzasadnienie, DataZlozenia,
            AdresEmail, Telefon, Podpis
        )
        VALUES
        (
            @ImieNazwisko, @NumerAlbumu, @Kierunek, @Stopien, @Semestr,
            @TrybStudiow, @RokAkademicki, @Przedmiot, @Prowadzacy,
            @TerminEgzaminu, @Uzasadnienie, @DataZlozenia,
            @AdresEmail, @Telefon, @Podpis
        );
        """;

        using var command = new SqliteCommand(query, connection);

        command.Parameters.AddWithValue("@ImieNazwisko", imieNazwisko);
        command.Parameters.AddWithValue("@NumerAlbumu", numerAlbumu);
        command.Parameters.AddWithValue("@Kierunek", kierunek);
        command.Parameters.AddWithValue("@Stopien", stopien);
        command.Parameters.AddWithValue("@Semestr", semestr);
        command.Parameters.AddWithValue("@TrybStudiow", trybStudiow);
        command.Parameters.AddWithValue("@RokAkademicki", rokAkademicki);
        command.Parameters.AddWithValue("@Przedmiot", przedmiot);
        command.Parameters.AddWithValue("@Prowadzacy", prowadzacy);
        command.Parameters.AddWithValue("@TerminEgzaminu", terminEgzaminu);
        command.Parameters.AddWithValue("@Uzasadnienie", uzasadnienie);
        command.Parameters.AddWithValue("@DataZlozenia", dataZlozenia);
        command.Parameters.AddWithValue("@AdresEmail", adresEmail);
        command.Parameters.AddWithValue("@Telefon", telefon);
        command.Parameters.AddWithValue("@Podpis", podpis);

        command.ExecuteNonQuery();
    }

    public List<string> ReadData()
    {
        List<string> results = new List<string>();

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string query = "SELECT * FROM Formularze ORDER BY Id DESC";

        using var command = new SqliteCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            string text =
                $"ID: {reader["Id"]} | " +
                $"{reader["ImieNazwisko"]} | " +
                $"Album: {reader["NumerAlbumu"]} | " +
                $"Przedmiot: {reader["Przedmiot"]} | " +
                $"Data: {reader["DataZlozenia"]}";

            results.Add(text);
        }

        return results;
    }
}