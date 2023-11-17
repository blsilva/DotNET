/*Para converter uma variável do tipo double em um tipo int em C#, 
você pode usar a função Convert.ToInt32 ou o tipo de conversão direta (int). 
Se a parte fracionária não puder ser representada como um número inteiro válido 
(por exemplo, se for maior que Int32.MaxValue ou menor que Int32.MinValue), 
ocorrerá um overflow, e o comportamento dependerá da manipulação de overflow 
configurada em seu ambiente.*/

//Exemplo em C#

using System;


class Program
{
    static void Main()
    {
        double valorDouble = 123.456;

        int resultado1 = Convert.ToInt32(valorDouble);

        int resultado2 = (int)valorDouble;

        Console.WriteLine($"Valor original (double): {valorDouble}");
        Console.WriteLine($"Convert.ToInt32: {resultado1}");
        Console.WriteLine($"Cast (int): {resultado2}");
    }
}

