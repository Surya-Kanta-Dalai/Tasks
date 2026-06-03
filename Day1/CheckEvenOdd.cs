// Check whether a number is Even or Odd.

using System;

class CheckEvenOdd {
	static void Main () {
		Console.Write("Enter a number: ");
		int num = int.Parse(Console.ReadLine());
		if(num%2==0) {
			Console.WriteLine("Even Number");
		} else {
			Console.WriteLine("Odd Number");
		}
	}
}
