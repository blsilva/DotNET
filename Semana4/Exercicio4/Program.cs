using System;

class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Aluno()
    {
        Nome = "Biancardy Lima";
        Idade = 29;
    }
}

class Program
{
    static void Main()
    {
        Aluno meuAluno = new Aluno();

        Console.WriteLine("Informações do Aluno:");
        Console.WriteLine($"Nome: {meuAluno.Nome}");
        Console.WriteLine($"Idade: {meuAluno.Idade}");
    }
}
