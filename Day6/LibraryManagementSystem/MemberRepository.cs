using Microsoft.Data.SqlClient;

public class MemberRepository
{
    public void AddMember()
    {
        Members member = ReadMemberDetails();
        if (string.IsNullOrWhiteSpace(member.MemberName))
        {
            Console.WriteLine("Member name is required.");
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            @"INSERT INTO Members (MemberName, Email, Phone, MembershipDate, Address)
              VALUES (@MemberName, @Email, @Phone, @MembershipDate, @Address)",
            con);

        AddMemberParameters(cmd, member);
        cmd.Parameters.AddWithValue("@MembershipDate", DateTime.Now);

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Member added!");
    }

    public void ViewMembers()
    {
        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            "SELECT MemberID, MemberName, Email, Phone, MembershipDate, Address FROM Members ORDER BY MemberID",
            con);

        con.Open();
        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nID | Name | Email | Phone | Joined | Address");
        Console.WriteLine("---------------------------------------------");

        while (reader.Read())
        {
            Console.WriteLine($"{reader["MemberID"]} | {reader["MemberName"]} | {reader["Email"]} | {reader["Phone"]} | {reader["MembershipDate"]} | {reader["Address"]}");
        }
    }

    public void UpdateMember()
    {
        int id = ReadInt("MemberID to update: ");
        if (id <= 0)
        {
            return;
        }

        Members member = ReadMemberDetails();
        if (string.IsNullOrWhiteSpace(member.MemberName))
        {
            Console.WriteLine("Member name is required.");
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand(
            @"UPDATE Members
              SET MemberName = @MemberName,
                  Email = @Email,
                  Phone = @Phone,
                  Address = @Address
              WHERE MemberID = @MemberID",
            con);

        cmd.Parameters.AddWithValue("@MemberID", id);
        AddMemberParameters(cmd, member);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Member updated!" : "Member not found.");
    }

    public void DeleteMember()
    {
        int id = ReadInt("MemberID to delete: ");
        if (id <= 0)
        {
            return;
        }

        using SqlConnection con = DBHelper.GetConnection();
        using SqlCommand cmd = new SqlCommand("DELETE FROM Members WHERE MemberID = @MemberID", con);
        cmd.Parameters.AddWithValue("@MemberID", id);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Member deleted!" : "Member not found.");
    }

    private static Members ReadMemberDetails()
    {
        Members member = new Members();

        Console.Write("Name: ");
        member.MemberName = Console.ReadLine() ?? string.Empty;

        Console.Write("Email: ");
        member.Email = Console.ReadLine() ?? string.Empty;

        Console.Write("Phone: ");
        member.Phone = Console.ReadLine() ?? string.Empty;

        Console.Write("Address: ");
        member.Address = Console.ReadLine() ?? string.Empty;

        return member;
    }

    private static void AddMemberParameters(SqlCommand cmd, Members member)
    {
        cmd.Parameters.AddWithValue("@MemberName", member.MemberName.Trim());
        cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(member.Email) ? DBNull.Value : member.Email.Trim());
        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(member.Phone) ? DBNull.Value : member.Phone.Trim());
        cmd.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(member.Address) ? DBNull.Value : member.Address.Trim());
    }

    private static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out int value) ? value : 0;
    }
}
