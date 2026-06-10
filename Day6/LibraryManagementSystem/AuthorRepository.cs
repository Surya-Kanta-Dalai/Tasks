using System;
using System.Collections.Generic;

public class AuthorRepository
{
    private List<Authors> authors = new List<Authors>();

    public void AddAuthor()
    {
        Console.Write("Enter Author Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Author Bio: ");
        string bio = Console.ReadLine();
        authors.Add(new Authors { Name = name, Bio = bio });
        Console.WriteLine("Author added successfully!");
    }

    public void UpdateAuthor()
    {
        Console.Write("Enter Author Name to Update: ");
        string name = Console.ReadLine();
        var author = authors.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (author != null)
        {
            Console.Write("Enter New Bio: ");
            author.Bio = Console.ReadLine();
            Console.WriteLine("Author updated successfully!");
        }
        else
        {
            Console.WriteLine("Author not found!");
        }
    }

    public void DeleteAuthor()
    {
        Console.Write("Enter Author Name to Delete: ");
        string name = Console.ReadLine();
        var author = authors.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (author != null)
        {
            authors.Remove(author);
            Console.WriteLine("Author deleted successfully!");
        }
        else
        {
            Console.WriteLine("Author not found!");
        }
    }

    public void ViewAuthors()
    {
        if (authors.Count == 0)
        {
            Console.WriteLine("No authors available.");
            return;
        }
        foreach (var author in authors)
        {
            Console.WriteLine($"Name: {author.Name}, Bio: {author.Bio}");
        }
    }
}
