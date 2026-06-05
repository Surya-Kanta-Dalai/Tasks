// 02 Total Marks : There are two types of questions in a Question Paper --- 1 type of question for which 'X' marks are awarded for the correct answer and the other type of question for which 'Y' marks are awarded for the correct answer. There are 'n1' questions of type 1 and 'n2' questions of type 2.
// A question will be awarded full marks if the answer is completely correct. Otherwise 0 marks will be awarded for that question.
// Given a mark scored by a student ('M') , find whether it is a valid mark as per this scoring system. 
// Input Format:
// Input consists of 5 integers that correspond to X, Y, N1, N2 and M respectively.
// Output Format:
// The first line of the output consists of a string that is either “Valid” or “Invalid”.
// If the first line of the output is valid, in the next line print the marks scored by the student in Type I questions and the marks scored by the student it Type II questions.
// In cases of multiple possible answers, print the case where the student must have answered the maximum number of Type 1 questions.

// Sample Input 1:
// 5
// 8
// 5
// 4
// 44
// Sample Output 1:
// Valid
// 4
// 3
// [Explanation :  4*5 + 3*8  = 44   // 4 "5 Marks" Questions and 3 "8 Marks" Questions are correct]

// Sample Input 2:
// 5
// 8
// 5
// 4
// 46
// Sample Output 2:
// Invalid

using System;

class TotalMarks
{
    static void Main()
    {
        int X = int.Parse(Console.ReadLine());
        int Y = int.Parse(Console.ReadLine());
        int N1 = int.Parse(Console.ReadLine());
        int N2 = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = N1; i >= 0; i--)
        {
            for (int j = 0; j <= N2; j++)
            {
                if (i * X + j * Y == M)
                {
                    Console.WriteLine("Valid");
                    Console.WriteLine(i);
                    Console.WriteLine(j);
                    found = true;
                    return;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Invalid");
        }
    }
}
