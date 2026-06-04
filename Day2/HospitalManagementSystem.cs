// Case Study 2: Hospital Management System
// Scenario : A hospital manages Doctors, Nurses, and Patients.
// Classes
// •	Person (Base Class)
// •	Doctor
// •	Nurse
// •	Patient
// Properties
// •	Id
// •	Name
// •	Department
// •	Disease
// Methods
// •	GetDetails()
// •	PerformDuty()
// OOP Concepts :
// Encapsulation
// •	Private patient records.
// Inheritance
// •	Doctor, Nurse, Patient inherit from Person.
// Polymorphism
// •	Different PerformDuty() implementation.
// Abstraction
// •	Abstract class Person.
// Activity Tasks
// 1.	Create Person abstract class.
// 2.	Create Doctor, Nurse, Patient classes.
// 3.	Override PerformDuty().
// 4.	Store all objects in a List.
// 5.	Display details using foreach loop.
// Expected Output
// Doctor Krishna is treating patients.
// Nurse Ravi is assisting doctors.
// Patient Anu is receiving treatment.

using System;
using System.Collections.Generic;

abstract class Person
{
    protected int id;
    protected string name;
    public Person(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
    public void GetDetails()
    {
        Console.WriteLine($"ID: {id}, Name: {name}");
    }
    public abstract void PerformDuty();
}

class Doctor : Person
{
    private string department;
    public Doctor(int id, string name, string department)
        : base(id, name)
    {
        this.department = department;
    }
    public override void PerformDuty()
    {
        Console.WriteLine($"Doctor {name} is treating patients.");
    }
}

class Nurse : Person
{
    private string department;
    public Nurse(int id, string name, string department)
        : base(id, name)
    {
        this.department = department;
    }
    public override void PerformDuty()
    {
        Console.WriteLine($"Nurse {name} is assisting doctors.");
    }
}

class Patient : Person
{
    private string disease;
    public Patient(int id, string name, string disease)
        : base(id, name)
    {
        this.disease = disease;
    }
    public override void PerformDuty()
    {
        Console.WriteLine($"Patient {name} is receiving treatment.");
    }
}

class HospitalManagementSystem
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        people.Add(new Doctor(1, "Krishna", "Cardiology"));
        people.Add(new Nurse(2, "Ravi", "Emergency"));
        people.Add(new Patient(3, "Anu", "Fever"));

        Console.WriteLine("---- Hospital Management System ----\n");

        foreach (Person person in people)
        {
            person.GetDetails();
            person.PerformDuty();
            Console.WriteLine();
        }
    }
}
