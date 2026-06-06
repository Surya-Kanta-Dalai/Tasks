class Library : IReader, ILibrarian
{
    private string currentBook = "";
    private Membership member;

    public void AddMember(Membership m)
    {
        member = m;
        Console.WriteLine("Member Added");
        member.ShowDetails();
    }

    public void IssueBook(string bookName)
    {
        if (currentBook == "")
        {
            currentBook = bookName;
            Console.WriteLine($"Book Issued: {bookName}");
        }
        else
        {
            Console.WriteLine("Book already issued.");
        }
    }

    public void ReadBook()
    {
        if (currentBook != "")
            Console.WriteLine($"Reading: {currentBook}");
        else
            Console.WriteLine("No book issued.");
    }

    public void ReturnBook(int days)
    {
        if (currentBook != "")
        {
            Console.WriteLine("Book Returned");
            if (days > member.MaxDays)
            {
                int fine = (days - member.MaxDays) * 10;
                Console.WriteLine($"Fine: ₹{fine}");
            }
            else
            {
                Console.WriteLine("No Fine");
            }
            currentBook = "";
        }
        else
        {
            Console.WriteLine("No book to return.");
        }
    }
}
