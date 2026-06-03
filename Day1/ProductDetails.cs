// Store Product Name and Price in a Dictionary and display them.

using System;
using System.Collections.Generic;

class ProductDetails {
    static void Main ()
    {
        Dictionary<string, int> pro = new Dictionary<string, int> ();    
        for (int i=0; i<2; i++) {
       		Console.Write("Enter Name: ");
		    String name = Console.ReadLine();
		    Console.Write("Enter Price: ");
		    int price = int.Parse(Console.ReadLine());
		    pro.Add(name, price);
        }
        Console.WriteLine();
        Console.WriteLine("Product List");
        Console.WriteLine("************");
	    foreach (KeyValuePair<string, int> kvp in pro) {
		    Console.WriteLine(kvp.Key+" "+kvp.Value);
	    }
    }
}
