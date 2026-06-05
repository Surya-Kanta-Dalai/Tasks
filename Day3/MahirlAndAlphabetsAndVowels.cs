// 05 Mahirl and Alphabets and Vowels : Mahirl's uncle Sam has just taught her about the vowels.
// To test her understanding on vowels, he gave her the following assignment.
// He gave her 2 words.
// She needs to remove all the consonants from the first word that are also present in the second word. After deleting the common consonants, if there are any 2 or more consequtive characters that are the same in the first word, then only one character ( first character) from the consequtive sequence should be retained and all the other characters in the consequtive sequence should be deleted.
// Can you please help Mahirl in completing this assignment?

// Input format: 
// Input consists of 2 strings --- The first word and the second word.
// Assume that the maximum length of the string is 50 and the 2 input strings consist of only lowercase and uppercase letters. While comparing 2 characters for similarity, don't consider case . i.e 'A' and 'a' are considered as same characters.
// Output Format: 
// Output consists of the final processed string.

// Sample Input 1:
// Amphiibian
// Technologies 
// Sample Output 1:
// Ampibia
// [Note : In this case, 'h' and 'n' are the common consonants in the 2 words]

// Sample Input 2:
// Aaaabcc
// bcd
// Sample Output 2 :
// A

using System;

class MahrilAndAlphabetsAndVowels
{
    static void Main()
    {
        Console.Write("Enter the first word: ");
        string first = Console.ReadLine();
        Console.Write("Enter the second word: ");
        string second = Console.ReadLine();
        Console.WriteLine(Ruled_String(first, second));
    }

    public static string Ruled_String(string s1, string s2)
    {
        s1 = s1.ToLower();
        s2 = s2.ToLower();
        string temp = "";
        foreach (char ch in s1)
        {
            bool isVowel = "aeiou".Contains(ch);
            if (isVowel || !s2.Contains(ch))
            {
                temp += ch;
            }
        }
        string res = "";
        for (int i = 0; i < temp.Length; i++)
        {
            if (i == 0 || temp[i] != temp[i - 1])
            {
                res += temp[i];
            }
        }
        res = char.ToUpper(res[0]) + res.Substring(1);
        return res;
    }
}
