class Program
{
    static void Main()
    {
        BookRepository bookRepo = new BookRepository();
        MemberRepository memberRepo = new MemberRepository();
        TransactionRepository transactionRepo = new TransactionRepository();
        AuthorRepository authorRepo = new AuthorRepository();
        CategoryRepository categoryRepo = new CategoryRepository();
        ReportRepository reportRepo = new ReportRepository();

        while (true)
        {
            Console.WriteLine("\n==== LIBRARY MANAGEMENT ====");
            Console.WriteLine("1. Book Management");
            Console.WriteLine("2. Author Management");
            Console.WriteLine("3. Category Management");
            Console.WriteLine("4. Member Management");
            Console.WriteLine("5. Issue Book");
            Console.WriteLine("6. Return Book");
            Console.WriteLine("7. Search Book");
            Console.WriteLine("8. Reports");
            Console.WriteLine("9. Exit");

            int choice = ReadChoice("Enter choice: ");

            try
            {
                switch (choice)
                {
                    case 1:
                        ShowBookMenu(bookRepo);
                        break;
                    case 2:
                        ShowAuthorMenu(authorRepo);
                        break;
                    case 3:
                        ShowCategoryMenu(categoryRepo);
                        break;
                    case 4:
                        ShowMemberMenu(memberRepo);
                        break;
                    case 5:
                        transactionRepo.IssueBook();
                        break;
                    case 6:
                        transactionRepo.ReturnBook();
                        break;
                    case 7:
                        transactionRepo.SearchBook();
                        break;
                    case 8:
                        ShowReportsMenu(reportRepo);
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void ShowBookMenu(BookRepository bookRepo)
    {
        Console.WriteLine("\n==== BOOK MANAGEMENT ====");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Update Book");
        Console.WriteLine("3. Delete Book");
        Console.WriteLine("4. View Books");

        switch (ReadChoice("Enter choice: "))
        {
            case 1:
                bookRepo.AddBook();
                break;
            case 2:
                bookRepo.UpdateBook();
                break;
            case 3:
                bookRepo.DeleteBook();
                break;
            case 4:
                bookRepo.ViewBooks();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static void ShowAuthorMenu(AuthorRepository authorRepo)
    {
        Console.WriteLine("\n==== AUTHOR MANAGEMENT ====");
        Console.WriteLine("1. Add Author");
        Console.WriteLine("2. Update Author");
        Console.WriteLine("3. Delete Author");
        Console.WriteLine("4. View Authors");

        switch (ReadChoice("Enter choice: "))
        {
            case 1:
                authorRepo.AddAuthor();
                break;
            case 2:
                authorRepo.UpdateAuthor();
                break;
            case 3:
                authorRepo.DeleteAuthor();
                break;
            case 4:
                authorRepo.ViewAuthors();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static void ShowCategoryMenu(CategoryRepository categoryRepo)
    {
        Console.WriteLine("\n==== CATEGORY MANAGEMENT ====");
        Console.WriteLine("1. Add Category");
        Console.WriteLine("2. Update Category");
        Console.WriteLine("3. Delete Category");
        Console.WriteLine("4. View Categories");

        switch (ReadChoice("Enter choice: "))
        {
            case 1:
                categoryRepo.AddCategory();
                break;
            case 2:
                categoryRepo.UpdateCategory();
                break;
            case 3:
                categoryRepo.DeleteCategory();
                break;
            case 4:
                categoryRepo.ViewCategories();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static void ShowMemberMenu(MemberRepository memberRepo)
    {
        Console.WriteLine("\n==== MEMBER MANAGEMENT ====");
        Console.WriteLine("1. Add Member");
        Console.WriteLine("2. Update Member");
        Console.WriteLine("3. Delete Member");
        Console.WriteLine("4. View Members");

        switch (ReadChoice("Enter choice: "))
        {
            case 1:
                memberRepo.AddMember();
                break;
            case 2:
                memberRepo.UpdateMember();
                break;
            case 3:
                memberRepo.DeleteMember();
                break;
            case 4:
                memberRepo.ViewMembers();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static void ShowReportsMenu(ReportRepository reportRepo)
    {
        Console.WriteLine("\n==== REPORTS ====");
        Console.WriteLine("1. Total Books");
        Console.WriteLine("2. Total Members");
        Console.WriteLine("3. Issued Books");
        Console.WriteLine("4. Overdue Books");
        Console.WriteLine("5. Most Borrowed Books");
        Console.WriteLine("6. Available Books");

        switch (ReadChoice("Enter choice: "))
        {
            case 1:
                reportRepo.ShowTotalBooks();
                break;
            case 2:
                reportRepo.ShowTotalMembers();
                break;
            case 3:
                reportRepo.ShowIssuedBooks();
                break;
            case 4:
                reportRepo.ShowOverdueBooks();
                break;
            case 5:
                reportRepo.ShowMostBorrowedBooks();
                break;
            case 6:
                reportRepo.ShowAvailableBooks();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static int ReadChoice(string prompt)
    {
        Console.Write(prompt);
        return int.TryParse(Console.ReadLine(), out int choice) ? choice : 0;
    }
}
