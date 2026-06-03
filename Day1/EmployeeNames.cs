// Store 5 employee names in a List and display them.

using System;
using System.Collections.Generic;

class EmployeeNames {
    static void Main ()
    {
        List<string> employees = new List<string> ();
        for (int i=0; i<5; i++) {
            Console.Write("Enter Employee Name: ");
            employees.Add(Console.ReadLine());
        }
        Console.WriteLine();
        Console.WriteLine("Employee List");
        Console.WriteLine("*************");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}
