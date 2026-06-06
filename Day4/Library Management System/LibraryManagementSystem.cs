// Case Study 2: Library Management System
// Scenario
// A library system manages:
// •	Book Issue
// •	Book Return
// •	Fine Calculation
// •	Email Alerts
// •	Membership Management
// ________________________________________

// Activity Questions
// 1.	Add a FacultyMembership class.
// 2.	Implement Email and SMS alerts.
// 3.	Create separate interfaces for Reader and Librarian.

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== LIBRARY MANAGEMENT APPLICATION =====");
        Library lib = new Library();

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("1. Student\n2. Faculty");
        Console.Write("Enter your choice(Enter Number): ");
        int type = int.Parse(Console.ReadLine());
        Membership member;
        if (type == 1)
            member = new StudentMembership(name);
        else if (type == 2)
            member = new FacultyMembership(name);
        else
        {
            Console.WriteLine("Wrong Input. Try Again.");
            return;
        }

        lib.AddMember(member);
        Console.Write("\nEnter Book name: ");
        String book = Console.ReadLine();
        lib.IssueBook(book);
        lib.ReadBook();

        Console.WriteLine("\nReturn Your Book");
        Console.Write("Enter Days Taken: ");
        int days = Convert.ToInt32(Console.ReadLine());
        lib.ReturnBook(days);

        Console.WriteLine("\nSelect Alart type: ");
        Console.WriteLine("1. Email Alart");
        Console.WriteLine("2. SMS Alart");
        Console.Write("Enter as number: ");
        int alart = Convert.ToInt32(Console.ReadLine());
        if (alart == 1)
        {
            AlertManager alert1 = new AlertManager(new EmailAlert());
            alert1.Notify("Book Returned");
            alert1.Notify("Please clear fine");
        }
        else if (alart == 2)
        {
            AlertManager alert2 = new AlertManager(new SMSAlert());
            alert2.Notify("Book Returned");
            alert2.Notify("Please clear fine");
        }
        else
        {
            AlertManager alert1 = new AlertManager(new EmailAlert());
            alert1.Notify("Book Returned");
            alert1.Notify("Please clear fine");
            AlertManager alert2 = new AlertManager(new SMSAlert());
            alert2.Notify("Book Returned");
            alert2.Notify("Please clear fine");
        }
        Console.WriteLine("\nThanks. Visit Again.");
    }
}
