using System;
using System.Linq.Expressions;

public class Example
{
    public static void Main()
    {
        String s;

        Console.Clear();
        s = Console.ReadLine();
        
        for(int i = 0; i < s.Length; i++)
        {
            if(char.IsLower(s[i]))
            {
                Console.WriteLine(char.ToUpper(s[i]));
            }
            else 
            {
                Console.WriteLine(char.ToLower(s[i]));
            }
        }

    }
}