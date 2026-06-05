// 04 Lucky String : A string is said to be a 'Lucky String' if it consists of a substring of length 'n' that consists
// of only letters 'P', 'S' and 'G' and there occurs atleast n/2 consequtive P's or S's or G's in the
// substring. Given a string find out if it is a lucky string or not.
// Input and Output Format :
// Input consists of an integer corresponding to the length of the substring followed by a string corresponding to the input string.
// Assume that the length of the substring is always even and the maximum length of the input string is 50.
// Assume that the string consists of only upper case letters.
// Output consists of a single string 'Yes' or 'No' or “Invalid”.
// Print “Invalid” if the length of the substring is greater than the string length. Print “Yes” if the given string is a lucky string. Print “No” if the given string is not a lucky string.
 
// Sample Input 1:
// 8
// FGHPSGGGGPPSABD
// Sample Output 1:
// Yes
 
// Sample Input 2:
// 8
// FGHPSGGGSPPSABD
// Sample Output 2:
// No
 
// Sample Input 3:
// 20
// FGHPSGGGSPPSABD
// Sample Output 3:
// Invalid

using System;

class LuckyString
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        if (n > s.Length)
        {
            Console.WriteLine("Invalid");
            return;
        }
        for (int i = 0; i <= s.Length - n; i++)
        {
            string sub = s.Substring(i, n);

            if (OnlyPSG(sub) && HasConsecutive(sub, n / 2))
            {
                Console.WriteLine("Yes");
                return;
            }
        }
        Console.WriteLine("No");
    }

    static bool OnlyPSG(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != 'P' && str[i] != 'S' && str[i] != 'G')
                return false;
        }
        return true;
    }

    static bool HasConsecutive(string str, int limit)
    {
        int count = 1;
        for (int i = 1; i < str.Length; i++)
        {
            if (str[i] == str[i - 1])
            {
                count++;
                if (count >= limit)
                    return true;
            }
            else
            {
                count = 1;
            }
        }
        return false;
    }
}
