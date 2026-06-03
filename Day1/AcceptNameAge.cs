// Create a program that accepts Name and Age and displays them.

using System;

public class AcceptNameAge {
    public static void Main (string [] args)
    {
        Console.Write("Enter a Name: ");
		String name = Console.ReadLine();
		Console.Write("Enter Age: ");
		int age = int.Parse(Console.ReadLine());
		Console.WriteLine();
		Console.WriteLine("User Details");
		Console.WriteLine("************");
		Console.WriteLine($"Name: {name}\nAge: {age}");
    }
}
