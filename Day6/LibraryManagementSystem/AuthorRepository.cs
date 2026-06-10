using Microsoft.Data.SqlClient;

public class AuthorRepository
{
    public void AddAuthor()
    {
        Console.Write("Author name: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Author name is required.");
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            "INSERT INTO Authors (AuthorName, Email, Phone) VALUES (@AuthorName, @Email, @Phone)",
            con);
        cmd.Parameters.AddWithValue("@AuthorName", name.Trim());
        cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : email.Trim());
        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(phone) ? DBNull.Value : phone.Trim());

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Author added!");
    }

    public void ViewAuthors()
    {
        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand("SELECT AuthorID, AuthorName, Email, Phone FROM Authors ORDER BY AuthorID", con);

        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nID | Name | Email | Phone");
        Console.WriteLine("-------------------------");

        while (reader.Read())
        {
            Console.WriteLine($"{reader["AuthorID"]} | {reader["AuthorName"]} | {reader["Email"]} | {reader["Phone"]}");
        }
    }

    public void UpdateAuthor()
    {
        int id = ReadInt("AuthorID to update: ");
        if (id <= 0)
        {
            return;
        }

        Console.Write("Author name: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Author name is required.");
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            "UPDATE Authors SET AuthorName = @AuthorName, Email = @Email, Phone = @Phone WHERE AuthorID = @AuthorID",
            con);
        cmd.Parameters.AddWithValue("@AuthorID", id);
        cmd.Parameters.AddWithValue("@AuthorName", name.Trim());
        cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? DBNull.Value : email.Trim());
        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(phone) ? DBNull.Value : phone.Trim());

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Author updated!" : "Author not found.");
    }

    public void DeleteAuthor()
    {
        int id = ReadInt("AuthorID to delete: ");
        if (id <= 0)
        {
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand("DELETE FROM Authors WHERE AuthorID = @AuthorID", con);
        cmd.Parameters.AddWithValue("@AuthorID", id);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Author deleted!" : "Author not found.");
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out int value) ? value : 0;
    }
}
