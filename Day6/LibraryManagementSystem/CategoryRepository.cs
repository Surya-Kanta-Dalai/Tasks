using Microsoft.Data.SqlClient;

public class CategoryRepository
{
    public void AddCategory()
    {
        Console.Write("Category name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Category name is required.");
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand("INSERT INTO Category (CategoryName) VALUES (@CategoryName)", con);
        cmd.Parameters.AddWithValue("@CategoryName", name.Trim());

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Category added!");
    }

    public void ViewCategories()
    {
        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand("SELECT CategoryID, CategoryName FROM Category ORDER BY CategoryID", con);

        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nID | Category");
        Console.WriteLine("-------------");

        while (reader.Read())
        {
            Console.WriteLine($"{reader["CategoryID"]} | {reader["CategoryName"]}");
        }
    }

    public void UpdateCategory()
    {
        int id = ReadInt("CategoryID to update: ");
        if (id <= 0)
        {
            return;
        }

        Console.Write("New category name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Category name is required.");
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            "UPDATE Category SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID",
            con);
        cmd.Parameters.AddWithValue("@CategoryID", id);
        cmd.Parameters.AddWithValue("@CategoryName", name.Trim());

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Category updated!" : "Category not found.");
    }

    public void DeleteCategory()
    {
        int id = ReadInt("CategoryID to delete: ");
        if (id <= 0)
        {
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand("DELETE FROM Category WHERE CategoryID = @CategoryID", con);
        cmd.Parameters.AddWithValue("@CategoryID", id);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Category deleted!" : "Category not found.");
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out int value) ? value : 0;
    }
}
