using System.Data;
using Microsoft.Data.SqlClient;

public class BookRepository
{
    public void AddBook()
    {
        Books book = new Books();

        Console.Write("Title: ");
        book.Title = Console.ReadLine();

        Console.Write("AuthorID: ");
        book.AuthorID = int.Parse(Console.ReadLine());

        Console.Write("CategoryID: ");
        book.CategoryID = int.Parse(Console.ReadLine());

        Console.Write("ISBN: ");
        book.ISBN = Console.ReadLine();

        Console.Write("Published Year: ");
        book.PublishedYear = int.Parse(Console.ReadLine());

        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("AddBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@AuthorID", book.AuthorID);
            cmd.Parameters.AddWithValue("@CategoryID", book.CategoryID);
            cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmd.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Added!");
        }
    }

    public void ViewBooks()
    {
        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("GetBooks", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nID | Title | Author | Category | ISBN | Year");
            Console.WriteLine("---------------------------------------------------");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["BookID"]} | {reader["Title"]} | {reader["AuthorName"]} | {reader["CategoryName"]} | {reader["ISBN"]} | {reader["PublishedYear"]}");
            }
        }
    }

    public void UpdateBook()
    {
        Console.Write("BookID to update: ");
        int id = int.Parse(Console.ReadLine());

        Books book = new Books();

        Console.Write("Title: ");
        book.Title = Console.ReadLine();

        Console.Write("AuthorID: ");
        book.AuthorID = int.Parse(Console.ReadLine());

        Console.Write("CategoryID: ");
        book.CategoryID = int.Parse(Console.ReadLine());

        Console.Write("ISBN: ");
        book.ISBN = Console.ReadLine();

        Console.Write("Published Year: ");
        book.PublishedYear = int.Parse(Console.ReadLine());

        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("UpdateBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BookID", id);
            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@AuthorID", book.AuthorID);
            cmd.Parameters.AddWithValue("@CategoryID", book.CategoryID);
            cmd.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmd.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Updated!");
        }
    }

    public void DeleteBook()
    {
        Console.Write("BookID to delete: ");
        int id = int.Parse(Console.ReadLine());

        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("DeleteBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BookID", id);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Deleted!");
        }
    }
}
