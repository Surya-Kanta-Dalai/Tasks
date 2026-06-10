using Microsoft.Data.SqlClient;

public class BookRepository
{
    public void AddBook()
    {
        Books book = ReadBookDetails();
        if (string.IsNullOrWhiteSpace(book.Title) || book.AuthorID <= 0 || book.CategoryID <= 0)
        {
            Console.WriteLine("Title, AuthorID, and CategoryID are required.");
            return;
        }

        int copies = ReadInt("Total copies: ");
        if (copies <= 0)
        {
            Console.WriteLine("Total copies must be greater than zero.");
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            @"INSERT INTO Books (BookName, AuthorID, CategoryID, ISBN, PublishedYear, TotalCopies, AvailableCopies)
              VALUES (@BookName, @AuthorID, @CategoryID, @ISBN, @PublishedYear, @TotalCopies, @AvailableCopies)",
            con);

        AddBookParameters(cmd, book);
        cmd.Parameters.AddWithValue("@TotalCopies", copies);
        cmd.Parameters.AddWithValue("@AvailableCopies", copies);

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Book added!");
    }

    public void ViewBooks()
    {
        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            @"SELECT b.BookID, b.BookName, a.AuthorName, c.CategoryName, b.ISBN, b.PublishedYear,
                     b.TotalCopies, b.AvailableCopies
              FROM Books b
              INNER JOIN Authors a ON b.AuthorID = a.AuthorID
              INNER JOIN Category c ON b.CategoryID = c.CategoryID
              ORDER BY b.BookID",
            con);

        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nID | Title | Author | Category | ISBN | Year | Total | Available");
        Console.WriteLine("----------------------------------------------------------------");

        while (reader.Read())
        {
            Console.WriteLine($"{reader["BookID"]} | {reader["BookName"]} | {reader["AuthorName"]} | {reader["CategoryName"]} | {reader["ISBN"]} | {reader["PublishedYear"]} | {reader["TotalCopies"]} | {reader["AvailableCopies"]}");
        }
    }

    public void UpdateBook()
    {
        int id = ReadInt("BookID to update: ");
        if (id <= 0)
        {
            return;
        }

        Books book = ReadBookDetails();
        int totalCopies = ReadInt("Total copies: ");
        int availableCopies = ReadInt("Available copies: ");

        if (string.IsNullOrWhiteSpace(book.Title) || book.AuthorID <= 0 || book.CategoryID <= 0 || totalCopies < 0 || availableCopies < 0)
        {
            Console.WriteLine("Invalid book details.");
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            @"UPDATE Books
              SET BookName = @BookName,
                  AuthorID = @AuthorID,
                  CategoryID = @CategoryID,
                  ISBN = @ISBN,
                  PublishedYear = @PublishedYear,
                  TotalCopies = @TotalCopies,
                  AvailableCopies = @AvailableCopies
              WHERE BookID = @BookID",
            con);

        cmd.Parameters.AddWithValue("@BookID", id);
        AddBookParameters(cmd, book);
        cmd.Parameters.AddWithValue("@TotalCopies", totalCopies);
        cmd.Parameters.AddWithValue("@AvailableCopies", availableCopies);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Book updated!" : "Book not found.");
    }

    public void DeleteBook()
    {
        int id = ReadInt("BookID to delete: ");
        if (id <= 0)
        {
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE BookID = @BookID", con);
        cmd.Parameters.AddWithValue("@BookID", id);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Book deleted!" : "Book not found.");
    }

    private static Books ReadBookDetails()
    {
        Books book = new Books();

        Console.Write("Title: ");
        book.Title = Console.ReadLine() ?? string.Empty;

        book.AuthorID = ReadInt("AuthorID: ");
        book.CategoryID = ReadInt("CategoryID: ");

        Console.Write("ISBN: ");
        book.ISBN = Console.ReadLine() ?? string.Empty;

        book.PublishedYear = ReadInt("Published year: ");

        return book;
    }

    private static void AddBookParameters(SqlCommand cmd, Books book)
    {
        cmd.Parameters.AddWithValue("@BookName", book.Title.Trim());
        cmd.Parameters.AddWithValue("@AuthorID", book.AuthorID);
        cmd.Parameters.AddWithValue("@CategoryID", book.CategoryID);
        cmd.Parameters.AddWithValue("@ISBN", string.IsNullOrWhiteSpace(book.ISBN) ? DBNull.Value : book.ISBN.Trim());
        cmd.Parameters.AddWithValue("@PublishedYear", book.PublishedYear <= 0 ? DBNull.Value : book.PublishedYear);
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out int value) ? value : 0;
    }
}
