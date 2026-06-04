// Case Study 3: E-Commerce Application
// Scenario : An online shopping application sells multiple products.
// Classes
// •	Product
// •	Electronics
// •	Clothing
// •	Grocery
// Properties
// •	ProductId
// •	ProductName
// •	Price
// Methods
// •	CalculateDiscount()
// •	DisplayProduct()
// OOP Concepts :
// Encapsulation
// •	Price should be protected.
// Inheritance
// •	Product → Electronics, Clothing, Grocery.
// Polymorphism
// •	Different discount calculation for each category.
// Abstraction
// •	Abstract method CalculateDiscount().
// Activity Tasks
// 1.	Create Product abstract class.
// 2.	Create three product categories.
// 3.	Implement different discount logic.
// 4.	Calculate final selling price.
// 5.	Display product information.
// Expected Output
// Laptop
// Original Price : 50000
// Discount : 10%
// Final Price : 45000

// T-Shirt
// Original Price : 1000
// Discount : 20%
// Final Price : 800

using System;
using System.Collections.Generic;

abstract class Product
{
    protected int productId;
    protected string productName;
    protected decimal price;
    public Product(int id, string name, decimal price)
    {
        this.productId = id;
        this.productName = name;
        this.price = price;
    }

    public abstract decimal CalculateDiscount();
    public void DisplayProduct()
    {
        decimal discount = CalculateDiscount();
        decimal finalPrice = price - discount;

        Console.WriteLine($"{productName}");
        Console.WriteLine($"Original Price : {price}");
        Console.WriteLine($"Discount : {(discount / price) * 100}%");
        Console.WriteLine($"Final Price : {finalPrice}\n");
    }
}

class Electronics : Product
{
    public Electronics(int id, string name, decimal price)
        : base(id, name, price) { }
    public override decimal CalculateDiscount()
    {
        return price * 0.10m;
    }
}

class Clothing : Product
{
    public Clothing(int id, string name, decimal price)
        : base(id, name, price) { }
    public override decimal CalculateDiscount()
    {
        return price * 0.20m;
    }
}

class Grocery : Product
{
    public Grocery(int id, string name, decimal price)
        : base(id, name, price) { }
    public override decimal CalculateDiscount()
    {
        return price * 0.05m;
    }
}

class ECommerceApplication
{
    public static void Main()
    {
        List<Product> products = new List<Product>();

        products.Add(new Electronics(1, "Laptop", 50000));
        products.Add(new Clothing(2, "T-Shirt", 1000));
        products.Add(new Grocery(3, "Rice Bag", 2000));

        Console.WriteLine("---- Product Details ----\n");

        foreach (Product product in products)
        {
            product.DisplayProduct();
        }
    }
}
