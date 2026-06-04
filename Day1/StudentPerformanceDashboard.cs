// Project: Student Performance Dashboard
//  Features
// •	Input student names and their marks.
// •	Show all students.
// •	Filter top-performing students using lambda.
// •	Validate numeric input and handle errors.
// Hints:-build a small C# console application project that simulates a Student Performance Dashboard. This will use generics, lambda expressions, and user input, along with basic validation

using System;
using System.Collections.Generic;
using System.Linq;

class StudentPerformanceDashboard {
    static void Main(string[] args) {
        Dictionary<string, double> students = new Dictionary<string, double>();
        Console.WriteLine("!!! Welcome to Student Dashboard !!!");
        Console.Write("How many records do you want to enter: ");
        if (!int.TryParse(Console.ReadLine(), out int num)) {
            Console.WriteLine("Invalid input.");
            return;
        }
        for (int i = 0; i < num; i++) {
            Console.Write("\nEnter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Mark (0-100): ");
            if (!double.TryParse(Console.ReadLine(), out double mark) || mark < 0 || mark > 100) {
                Console.WriteLine("Invalid mark. Try again.");
                i--;
                continue;
            }
            students[name] = mark;
        }

        Console.WriteLine("\n--- All Students ---");
        foreach (var student in students) {
            Console.WriteLine($"Name: {student.Key}, Marks: {student.Value}");
        }

        Console.WriteLine("\n--- Top Performers (Marks > 80) ---");

        var topStudents = students
            .Where(s => s.Value > 80)
            .OrderByDescending(s => s.Value);
        foreach (var student in topStudents) {
            Console.WriteLine($"Name: {student.Key}, Marks: {student.Value}");
        }
    }
}
