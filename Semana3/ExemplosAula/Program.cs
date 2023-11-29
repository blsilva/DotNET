using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Por favor, insira um número: ");
            string userInput = Console.ReadLine();

            int numero = Convert.ToInt32(userInput);

            Console.WriteLine($"Você inseriu o número: {numero}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Por favor, insira um número válido.");
        }
    }
}
