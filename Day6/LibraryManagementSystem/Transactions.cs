public class Transaction
{
    public int TransactionID { get; set; }
    public int BookID { get; set; }
    public int MemberID { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Status { get; set; }
}
