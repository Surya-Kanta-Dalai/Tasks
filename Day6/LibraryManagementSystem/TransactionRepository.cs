using System.Data;
using Microsoft.Data.SqlClient;

public class TransactionRepository
{
    public void IssueBook()
    {
        Console.Write("BookID: ");
        int bookId = int.Parse(Console.ReadLine());

        Console.Write("MemberID: ");
        int memberId = int.Parse(Console.ReadLine());

        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("IssueBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BookID", bookId);
            cmd.Parameters.AddWithValue("@MemberID", memberId);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("✅ Book Issued!");
        }
    }

    public void ReturnBook()
    {
        Console.Write("TransactionID: ");
        int id = int.Parse(Console.ReadLine());

        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("ReturnBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionID", id);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("✅ Book Returned!");
        }
    }

    public void SearchBook()
    {
        Console.Write("Enter Book Title or Author Name: ");
        string keyword = Console.ReadLine();

        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("SearchBooks", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Keyword", keyword);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nSearch Results:");
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["BookID"]}, Title: {reader["Title"]}, Author: {reader["AuthorName"]}");
            }
        }
    }
}
