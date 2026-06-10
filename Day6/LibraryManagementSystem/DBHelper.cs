using Microsoft.Data.SqlClient;
using System.Text.Json;

public class DBHelper
{
    private static string _connectionString;

    static DBHelper()
    {
        _connectionString = GetConnectionStringFromConfig();
    }

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }

    private static string GetConnectionStringFromConfig()
    {
        try
        {
            if (File.Exists("appsettings.json"))
            {
                string json = File.ReadAllText("appsettings.json");
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    var connString = doc.RootElement
                        .GetProperty("ConnectionStrings")
                        .GetProperty("DefaultConnection")
                        .GetString();
                    return connString;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading config: {ex.Message}");
        }

        // Fallback connection string
        return "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;Encrypt=False;";
    }
}
