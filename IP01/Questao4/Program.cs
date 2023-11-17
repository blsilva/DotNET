using System;
class Program
{
    static void Main()
    {
        int x = 10;
        int y = 3;

        int adicao = x + y;
        Console.WriteLine($"Adição: {adicao}");

        int subtracao = x - y;
        Console.WriteLine($"Subtração: {subtracao}");

        int multiplicacao = x * y;
        Console.WriteLine($"Multiplicação: {multiplicacao}");

        int divisao = x / y;
        Console.WriteLine($"Divisão: {divisao}");

        double divisaoComDecimal = (double)x / y;
        Console.WriteLine($"Divisão com parte decimal: {divisaoComDecimal}");
    }
}