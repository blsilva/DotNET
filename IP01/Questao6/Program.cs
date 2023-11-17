using System;

class Program
{
    static void Main()
    {
        string str1 = "Hello";
        string str2 = "World";

        if (str1.Equals(str2))
        {
            Console.WriteLine($"{str1} é igual a {str2}");
        }
        else
        {
            Console.WriteLine($"{str1} não é igual a {str2}");
        }

        if (str1 == str2)
        {
            Console.WriteLine($"{str1} é igual a {str2}");
        }
        else
        {
            Console.WriteLine($"{str1} não é igual a {str2}");
        }
    }
}
