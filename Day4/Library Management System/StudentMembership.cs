class StudentMembership : Membership
{
    public StudentMembership(string name)
    {
        MemberName = name;
        MaxDays = 15;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Student Member: {MemberName}, Days Allowed: {MaxDays}");
    }
}
