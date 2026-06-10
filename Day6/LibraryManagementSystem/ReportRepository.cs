using Microsoft.Data.SqlClient;

public class ReportRepository
{
    public void ShowTotalBooks()
    {
        Console.WriteLine($"Total books: {ExecuteScalarInt("SELECT ISNULL(SUM(TotalCopies), 0) FROM Books")}");
    }

    public void ShowTotalMembers()
    {
        Console.WriteLine($"Total members: {ExecuteScalarInt("SELECT COUNT(*) FROM Members")}");
    }

    public void ShowIssuedBooks()
    {
        PrintBookTransactionReport(
            @"SELECT t.TransactionID, b.BookName, m.MemberName, t.IssueDate, t.DueDate
              FROM [Transactions] t
              INNER JOIN Books b ON t.BookID = b.BookID
              INNER JOIN Members m ON t.MemberID = m.MemberID
              WHERE t.ReturnDate IS NULL
              ORDER BY t.IssueDate DESC",
            "Issued books");
    }

    public void ShowOverdueBooks()
    {
        PrintBookTransactionReport(
            @"SELECT t.TransactionID, b.BookName, m.MemberName, t.IssueDate, t.DueDate
              FROM [Transactions] t
              INNER JOIN Books b ON t.BookID = b.BookID
              INNER JOIN Members m ON t.MemberID = m.MemberID
              WHERE t.ReturnDate IS NULL AND t.DueDate < GETDATE()
              ORDER BY t.DueDate",
            "Overdue books");
    }

    public void ShowMostBorrowedBooks()
    {
        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            @"SELECT TOP 10 b.BookName, COUNT(*) AS BorrowCount
              FROM [Transactions] t
              INNER JOIN Books b ON t.BookID = b.BookID
              GROUP BY b.BookName
              ORDER BY BorrowCount DESC",
            con);

        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nMost borrowed books:");
        while (reader.Read())
        {
            Console.WriteLine($"{reader["BookName"]} - {reader["BorrowCount"]} borrow(s)");
        }
    }

    public void ShowAvailableBooks()
    {
        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            @"SELECT BookID, BookName, AvailableCopies
              FROM Books
              WHERE AvailableCopies > 0
              ORDER BY BookName",
            con);

        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nAvailable books:");
        while (reader.Read())
        {
            Console.WriteLine($"{reader["BookID"]} | {reader["BookName"]} | Available: {reader["AvailableCopies"]}");
        }
    }

    private static int ExecuteScalarInt(string sql)
    {
        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(sql, con);

        con.Open();
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    private static void PrintBookTransactionReport(string sql, string title)
    {
        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(sql, con);

        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine($"\n{title}:");
        while (reader.Read())
        {
            Console.WriteLine($"{reader["TransactionID"]} | {reader["BookName"]} | {reader["MemberName"]} | Issue: {reader["IssueDate"]} | Due: {reader["DueDate"]}");
        }
    }
}
