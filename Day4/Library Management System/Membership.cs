abstract class Membership
{
    public string MemberName { get; set; }
    public int MaxDays { get; set; }

    public abstract void ShowDetails();
}
