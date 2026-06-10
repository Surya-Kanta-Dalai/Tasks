using Microsoft.Data.SqlClient;

public class TransactionRepository
{
    public void IssueBook()
    {
        int bookId = ReadInt("BookID: ");
        int memberId = ReadInt("MemberID: ");

        if (bookId <= 0 || memberId <= 0)
        {
            Console.WriteLine("BookID and MemberID are required.");
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        con.Open();
        using SqlTransaction transaction = con.BeginTransaction();

        try
        {
            using SqlCommand checkCmd = new SqlCommand(
                "SELECT AvailableCopies FROM Books WHERE BookID = @BookID",
                con,
                transaction);
            checkCmd.Parameters.AddWithValue("@BookID", bookId);

            object result = checkCmd.ExecuteScalar();
            if (result == null)
            {
                Console.WriteLine("Book not found.");
                transaction.Rollback();
                return;
            }

            int availableCopies = Convert.ToInt32(result);
            if (availableCopies <= 0)
            {
                Console.WriteLine("No copies available for this book.");
                transaction.Rollback();
                return;
            }

            using SqlCommand issueCmd = new SqlCommand(
                @"INSERT INTO [Transactions] (BookID, MemberID, IssueDate, DueDate, Fine)
                  VALUES (@BookID, @MemberID, @IssueDate, @DueDate, @Fine)",
                con,
                transaction);
            issueCmd.Parameters.AddWithValue("@BookID", bookId);
            issueCmd.Parameters.AddWithValue("@MemberID", memberId);
            issueCmd.Parameters.AddWithValue("@IssueDate", DateTime.Now);
            issueCmd.Parameters.AddWithValue("@DueDate", DateTime.Now.AddDays(14));
            issueCmd.Parameters.AddWithValue("@Fine", 0m);
            issueCmd.ExecuteNonQuery();

            using SqlCommand updateCmd = new SqlCommand(
                "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookID = @BookID",
                con,
                transaction);
            updateCmd.Parameters.AddWithValue("@BookID", bookId);
            updateCmd.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Book issued!");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine($"Could not issue book: {ex.Message}");
        }
    }

    public void ReturnBook()
    {
        int transactionId = ReadInt("TransactionID: ");
        if (transactionId <= 0)
        {
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        con.Open();
        using SqlTransaction transaction = con.BeginTransaction();

        try
        {
            using SqlCommand findCmd = new SqlCommand(
                "SELECT BookID, DueDate FROM [Transactions] WHERE TransactionID = @TransactionID AND ReturnDate IS NULL",
                con,
                transaction);
            findCmd.Parameters.AddWithValue("@TransactionID", transactionId);

            using SqlDataReader reader = findCmd.ExecuteReader();
            if (!reader.Read())
            {
                Console.WriteLine("Active transaction not found.");
                transaction.Rollback();
                return;
            }

            int bookId = Convert.ToInt32(reader["BookID"]);
            DateTime dueDate = Convert.ToDateTime(reader["DueDate"]);
            reader.Close();

            decimal fine = CalculateFine(dueDate, DateTime.Now);

            using SqlCommand returnCmd = new SqlCommand(
                "UPDATE [Transactions] SET ReturnDate = @ReturnDate, Fine = @Fine WHERE TransactionID = @TransactionID",
                con,
                transaction);
            returnCmd.Parameters.AddWithValue("@TransactionID", transactionId);
            returnCmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
            returnCmd.Parameters.AddWithValue("@Fine", fine);
            returnCmd.ExecuteNonQuery();

            using SqlCommand updateCmd = new SqlCommand(
                "UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE BookID = @BookID",
                con,
                transaction);
            updateCmd.Parameters.AddWithValue("@BookID", bookId);
            updateCmd.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine(fine > 0 ? $"Book returned! Fine: {fine:C}" : "Book returned!");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine($"Could not return book: {ex.Message}");
        }
    }

    public void SearchBook()
    {
        Console.Write("Enter book title or author name: ");
        string keyword = Console.ReadLine();

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            @"SELECT b.BookID, b.BookName, a.AuthorName, c.CategoryName, b.AvailableCopies
              FROM Books b
              INNER JOIN Authors a ON b.AuthorID = a.AuthorID
              INNER JOIN Category c ON b.CategoryID = c.CategoryID
              WHERE b.BookName LIKE @Keyword OR a.AuthorName LIKE @Keyword
              ORDER BY b.BookName",
            con);
        cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nSearch results:");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["BookID"]}, Title: {reader["BookName"]}, Author: {reader["AuthorName"]}, Category: {reader["CategoryName"]}, Available: {reader["AvailableCopies"]}");
        }
    }

    private static decimal CalculateFine(DateTime dueDate, DateTime returnDate)
    {
        int overdueDays = (returnDate.Date - dueDate.Date).Days;
        return overdueDays > 0 ? overdueDays * 5m : 0m;
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out int value) ? value : 0;
    }
}
