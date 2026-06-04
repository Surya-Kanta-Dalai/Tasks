// Case Study 4: Employee Payroll System
// Scenario : A company has permanent and contract employees.
// Classes
// •	Employee
// •	PermanentEmployee
// •	ContractEmployee
// Properties
// •	EmployeeId
// •	EmployeeName
// •	Salary
// Methods
// •	CalculateSalary()
// •	DisplayInfo()
// OOP Concepts :
// Encapsulation
// •	Salary should not be directly accessible.
// Inheritance
// •	PermanentEmployee and ContractEmployee inherit from Employee.
// Polymorphism
// •	Different salary calculation.
// Abstraction
// •	Abstract CalculateSalary() method.
// Activity Tasks
// 1.	Create Employee abstract class.
// 2.	Create PermanentEmployee and ContractEmployee.
// 3.	Calculate salary differently.
// 4.	Store employees in a collection.
// 5.	Display payroll report.
// Expected Output
// Employee: Krishna
// Type: Permanent
// Salary: 75000

// Employee: Ravi
// Type: Contract
// Salary: 45000

using System;
using System.Collections.Generic;

abstract class Employee
{
    protected int employeeId;
    protected string employeeName;
    protected decimal salary;
    public Employee(int id, string name, decimal salary)
    {
        this.employeeId = id;
        this.employeeName = name;
        this.salary = salary;
    }
    public abstract decimal CalculateSalary();
    public void DisplayInfo()
    {
        Console.WriteLine($"Employee: {employeeName}");
    }
}

class PermanentEmployee : Employee
{
    public PermanentEmployee(int id, string name, decimal salary)
        : base(id, name, salary) { }
    public override decimal CalculateSalary()
    {
        return salary + 15000;
    }
    public void DisplayDetails()
    {
        Console.WriteLine("Type: Permanent");
        Console.WriteLine($"Salary: {CalculateSalary()}\n");
    }
}

class ContractEmployee : Employee
{
    public ContractEmployee(int id, string name, decimal salary)
        : base(id, name, salary) { }
    public override decimal CalculateSalary()
    {
        // Example: Fixed salary (no bonus)
        return salary;
    }
    public void DisplayDetails()
    {
        Console.WriteLine("Type: Contract");
        Console.WriteLine($"Salary: {CalculateSalary()}\n");
    }
}

class PayrollSystem
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>();

        employees.Add(new PermanentEmployee(1, "Krishna", 60000));
        employees.Add(new ContractEmployee(2, "Ravi", 45000));

        Console.WriteLine("---- Payroll Report ----\n");

        foreach (Employee emp in employees)
        {
            emp.DisplayInfo();
            if (emp is PermanentEmployee p)
                p.DisplayDetails();
            else if (emp is ContractEmployee c)
                c.DisplayDetails();
        }
    }
}
