// Case Study 1: Banking Management System
// Scenario : A bank manages different types of accounts such as Savings and Current accounts.
// Requirements :
// Classes
// •	Account (Base Class)
// •	SavingsAccount
// •	CurrentAccount
// Properties
// •	AccountNumber
// •	CustomerName
// •	Balance
// Methods
// •	Deposit()
// •	Withdraw()
// •	DisplayDetails()
// OOP Concepts
// Encapsulation
// •	Balance should not be modified directly.
// Inheritance
// •	SavingsAccount and CurrentAccount inherit from Account.
// Polymorphism
// •	Override Withdraw() differently for each account type.
// Abstraction
// •	Create an abstract method CalculateInterest().
// Activity Tasks
// 1.	Create an Account base class.
// 2.	Create SavingsAccount and CurrentAccount classes.
// 3.	Implement Deposit and Withdraw.
// 4.	Calculate interest for SavingsAccount.
// 5.	Display account details using polymorphism.
// Expected Output
// Account: 1001
// Customer: Krishna
// Balance: 50000
// Interest Added: 2500
// Updated Balance: 52500

using System;

abstract class Account {
    private long accountNumber;
    private string customerName;
    private decimal balance;
    public Account(long numb, string name, decimal bal) {
        accountNumber = numb;
        customerName = name;
        balance = bal;
    }
    public void Deposit(decimal amount) {
        balance += amount;
        Console.WriteLine($"{amount} deposited successfully. Total balance: {balance}");
    }
    public virtual void Withdraw(decimal amount) {
        if (balance >= amount) {
            balance -= amount;
            Console.WriteLine($"{amount} withdrawn successfully. Balance: {balance}");
        } else {
            Console.WriteLine("Insufficient balance.");
        }
    }

    public void DisplayDetails() {
        Console.WriteLine($"Account: {accountNumber}");
        Console.WriteLine($"Customer: {customerName}");
        Console.WriteLine($"Balance: {balance}");
    }
    public abstract void CalculateInterest();
}

class SavingsAccount : Account {
    static long numb = 1001;
    public SavingsAccount(string name)
        : base(numb++, name, 0.0m) {
    }
    public override void CalculateInterest() {
        decimal interest = balance * 0.05m;
        balance += interest;
        Console.WriteLine($"Interest Added: {interest}");
        Console.WriteLine($"Updated Balance: {balance}");
    }
}

class CurrentAccount : Account {
    static long numb = 2001;
    public CurrentAccount(string name)
        : base(numb++, name, 0.0m) {
    }
    public override void CalculateInterest() {
        Console.WriteLine("No interest for Current Account.");
    }
}

class BankingManagementSystem {
    public static void Main(string[] args) {
        Console.Write("Enter Customer Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Select Account Type:");
        Console.WriteLine("1. Savings");
        Console.WriteLine("2. Current");

        Console.Write("Enter your Choice: ");
        int type = int.Parse(Console.ReadLine());

        Account account;

        if (type == 1) {
            account = new SavingsAccount(name);
        } else if (type == 2) {
            account = new CurrentAccount(name);
        } else {
            Console.WriteLine("Invalid choice.");
            return;
        }

        account.DisplayDetails();

        account.Deposit(5000);
        account.Withdraw(2000);

        account.CalculateInterest();
    }
}
