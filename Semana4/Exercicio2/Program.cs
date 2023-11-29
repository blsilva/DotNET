using System;

class Veiculo
{
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }

    public int IdadeVeiculo
    {
        get
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - Ano;
        }
    }
}

class Program
{
    static void Main()
    {
        Veiculo meuVeiculo = new Veiculo();

        meuVeiculo.Modelo = "Carro Modelo X";
        meuVeiculo.Ano = 2022;
        meuVeiculo.Cor = "Azul";

        Console.WriteLine("Informações do Veículo:");
        Console.WriteLine($"Modelo: {meuVeiculo.Modelo}");
        Console.WriteLine($"Ano: {meuVeiculo.Ano}");
        Console.WriteLine($"Cor: {meuVeiculo.Cor}");
        Console.WriteLine($"Idade do Veículo: {meuVeiculo.IdadeVeiculo} anos");
    }
}
