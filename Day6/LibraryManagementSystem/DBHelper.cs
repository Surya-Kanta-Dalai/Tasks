using Microsoft.Data.SqlClient;

public class DBHelper
{
    public static SqlConnection GetConnection()
    {
        string connString = "Server='INBGP7NR24\\SQLEXPRESS';Database=LibraryDB;Trusted_Connection=True;";
        return new SqlConnection(connString);
    }
}
