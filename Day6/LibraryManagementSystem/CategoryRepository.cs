using System;
using System.Collections.Generic;

public class BookRepository
{
    private List<Book> books = new List<Book>();

    public void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author name: ");
        string author = Console.ReadLine();
        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        books.Add(new Book { Title = title, Author = author, Category = category });
        Console.WriteLine("Book added successfully!");
    }

    public void UpdateBook()
    {
        Console.Write("Enter book title to update: ");
        string title = Console.ReadLine();
        Book book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (book != null)
        {
            Console.Write("Enter new author name: ");
            book.Author = Console.ReadLine();
            Console.Write("Enter new category: ");
            book.Category = Console.ReadLine();
            Console.WriteLine("Book updated successfully!");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void DeleteBook()
    {
        Console.Write("Enter book title to delete: ");
        string title = Console.ReadLine();
        Book book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine("Book deleted successfully!");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Category: {book.Category}");
        }
    }
}
