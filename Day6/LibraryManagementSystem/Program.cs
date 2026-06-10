class Program
{
    static void Main()
    {
        BookRepository bookRepo = new BookRepository();
        MemberRepository memberRepo = new MemberRepository();
        TransactionRepository transRepo = new TransactionRepository();
        AuthorRepository authorRepo = new AuthorRepository();
        CategoryRepository categoryRepo = new CategoryRepository();

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

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n==== BOOK MANAGEMENT ====");
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. Update Book");
                    Console.WriteLine("3. Delete Book");
                    Console.WriteLine("4. View Books");
                    Console.Write("Enter choice: ");
                    int book = int.Parse(Console.ReadLine());
                    switch (book)
                    {
                        case 1: bookRepo.AddBook(); break;
                        case 2: bookRepo.UpdateBook(); break;
                        case 3: bookRepo.DeleteBook(); break;
                        case 4: bookRepo.ViewBooks(); break;
                        default: Console.WriteLine("Invalid choice"); break;
                    }
                    break;
                case 2:
                    Console.WriteLine("\n==== AUTHOR MANAGEMENT ====");
                    Console.WriteLine("1. Add Author");
                    Console.WriteLine("2. Update Author");
                    Console.WriteLine("3. Delete Author");
                    Console.WriteLine("4. View Author");
                    Console.Write("Enter choice: ");
                    int author = int.Parse(Console.ReadLine());
                    switch (author)
                    {
                        case 1: authorRepo.AddAuthor(); break;
                        case 2: authorRepo.UpdateAuthor(); break;
                        case 3: authorRepo.DeleteAuthor(); break;
                        case 4: authorRepo.ViewAuthors(); break;
                        default: Console.WriteLine("Invalid choice"); break;
                    }
                    break;
                case 3:
                    Console.WriteLine("\n==== CATEGORY MANAGEMENT ====");
                    Console.WriteLine("1. Add Category");
                    Console.WriteLine("2. Update Category");
                    Console.WriteLine("3. Delete Category");
                    Console.WriteLine("4. View Category");
                    Console.Write("Enter choice: ");
                    int category = int.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("\n==== MEMBER MANAGEMENT ====");
                    Console.WriteLine("1. Add Member");
                    Console.WriteLine("2. Update Member");
                    Console.WriteLine("3. Delete Member");
                    Console.WriteLine("4. View Members");
                    Console.Write("Enter choice: ");
                    int member = int.Parse(Console.ReadLine());
                    break;
                case 5: transRepo.IssueBook(); break;
                case 6: transRepo.ReturnBook(); break;
                case 7: transRepo.SearchBook(); break;
                case 8:
                    Console.WriteLine("\n==== REPORTS ====");
                    Console.WriteLine("1. Total Books");
                    Console.WriteLine("2. Total Members");
                    Console.WriteLine("3. Issued Books");
                    Console.WriteLine("4. Overdue Books");
                    Console.WriteLine("5. Most Borrowed Books");
                    Console.WriteLine("6. Available Books");
                    Console.Write("Enter choice: ");
                    int report = int.Parse(Console.ReadLine());
                    break;
                case 9: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}
