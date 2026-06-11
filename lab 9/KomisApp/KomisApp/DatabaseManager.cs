using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseManager
{
    private string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\KomisDatabase.mdf;Integrated Security=True";

    public void WriteData(string[] fields)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query =
                "INSERT INTO Entries (Field1, Field2, Field3, Field4, Field5, Field6, Field7, Field8, Field9, Field10, Field11, Field12, Field13, Field14, Field15) " +
                "VALUES (@F1,@F2,@F3,@F4,@F5,@F6,@F7,@F8,@F9,@F10,@F11,@F12,@F13,@F14,@F15)";

            SqlCommand cmd = new SqlCommand(query, connection);
            for (int i = 0; i < 15; i++)
                cmd.Parameters.AddWithValue("@F" + (i + 1), fields[i]);

            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public DataTable ReadData()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Entries";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}