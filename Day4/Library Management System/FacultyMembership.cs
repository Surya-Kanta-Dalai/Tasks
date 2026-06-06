class FacultyMembership : Membership
{
    public FacultyMembership(string name)
    {
        MemberName = name;
        MaxDays = 30;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Faculty Member: {MemberName}, Days Allowed: {MaxDays}");
    }
}
