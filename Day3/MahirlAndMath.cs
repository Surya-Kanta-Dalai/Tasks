// 03 Mahirl and Math : Mahirl's uncle Sam was teaching her addition and multiplication. She started doing all the basic exercises in addition and multiplication correctly.
// To challenge her more, Sam asked her an interesting question. He asked her to start with number 10. The only 3 operations that Mahirl can perform repeatedly are +2, -1 and *3. Given a target number N, Mahirl has to find the minimal number of operations she should use to get N starting from number 10.
// For example if the target number is 33, for reaching 33 from 10, 4 operation invocations are required : one *3 and two +2 and one -1. 
// For example if the target number is 28, for reaching 28 from 10, 3 operation invocations are required : one *3 and two -1.
// Being a 6 year old kid, this problem was quite difficult for Mahirl to solve. Can you please help her out in solving this problem?

// Input Format:
// Input consists of an integer that corresponds to N. 
// Output Format:
// Output consists of an integer that corresponds to the minimal amount of operations Mahirl has to use to reach N starting from 10.

// Sample Input 1:
// 33
// Sample Output 1:
// 4

// Sample Input 2:
// 28
// Sample Output 2:
// 3

using System;

class MahirlAndMath
{
    static void Main()
    {
        Console.Write("Enter a Number: ");
        int target = int.Parse(Console.ReadLine());
        Console.WriteLine(MinOperations(target));
    }

    static int MinOperations(int target)
    {
        int num = 10;
        int steps = 0;
        while (num != target)
        {
            int op1 = num * 3;
            int op2 = num + 2;
            int op3 = num - 1;

            int diff1 = Math.Abs(target - op1);
            int diff2 = Math.Abs(target - op2);
            int diff3 = Math.Abs(target - op3);

            int min = Math.Min(diff1, Math.Min(diff2, diff3));

            if (diff1 == min)
            {
                num = op1;
            }
            else if (diff2 == min)
            {
                num = op2;
            }
            else
            {
                num = op3;
            }

            steps++;
        }
        return steps;
    }
}
