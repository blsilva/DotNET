using System;

class Program
{
    static void Main()
    {
        int num1 = 7;
        int num2 = 3;
        int num3 = 10;

        bool condicao1 = num1 > num2;

        bool condicao2 = num3 == (num1 + num2);

        if (condicao1 && condicao2)
        {
            Console.WriteLine("num1 é maior do que num2 e num3 é igual a num1 + num2.");
        }
        else
        {
            Console.WriteLine("As condições não são atendidas.");
        }
    }
}
