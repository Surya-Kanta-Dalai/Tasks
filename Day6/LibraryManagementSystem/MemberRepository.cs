using Microsoft.Data.SqlClient;
using System.Data;

public class MemberRepository
{
    public void AddMember()
    {
        Members member = new Members();

        Console.Write("Name: ");
        member.MemberName = Console.ReadLine();

        Console.Write("Email: ");
        member.Email = Console.ReadLine();

        Console.Write("Phone: ");
        member.Phone = Console.ReadLine();

        Console.Write("Address: ");
        member.Address = Console.ReadLine();

        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("AddMember", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", member.MemberName);
            cmd.Parameters.AddWithValue("@Email", member.Email);
            cmd.Parameters.AddWithValue("@Phone", member.Phone);
            cmd.Parameters.AddWithValue("@Address", member.Address);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Member Added!");
        }
    }

    public void ViewMembers()
    {
        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Members", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nID\tName\tEmail\tPhone\tAddress");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["MemberID"]}\t{reader["MemberName"]}\t{reader["Email"]}\t{reader["Phone"]}\t{reader["Address"]}");
            }
        }
    }

    public void UpdateMember()
    {
        Console.Write("MemberID to update: ");
        int id = int.Parse(Console.ReadLine());

        Members member = new Members();

        Console.Write("Name: ");
        member.MemberName = Console.ReadLine();

        Console.Write("Email: ");
        member.Email = Console.ReadLine();

        Console.Write("Phone: ");
        member.Phone = Console.ReadLine();

        Console.Write("Address: ");
        member.Address = Console.ReadLine();

        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("UpdateMember", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MemberID", id);
            cmd.Parameters.AddWithValue("@Name", member.MemberName);
            cmd.Parameters.AddWithValue("@Email", member.Email);
            cmd.Parameters.AddWithValue("@Phone", member.Phone);
            cmd.Parameters.AddWithValue("@Address", member.Address);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Member Updated!");
        }
    }

    public void DeleteMember()
    {
        Console.Write("MemberID to delete: ");
        int id = int.Parse(Console.ReadLine());

        using (SqlConnection con = DBHelper.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("DeleteMember", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MemberID", id);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Member Deleted!");
        }
    }
}
