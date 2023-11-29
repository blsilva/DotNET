using System;

class Program
{
    static void Main()
    {
        Medico medico = new Medico("Dr. José", new DateTime(1980, 1, 1), "12345678901", "CRM1234");
        Paciente paciente = new Paciente("Maria", new DateTime(1990, 5, 10), "98765432109", Sexo.Feminino, "Febre");

        Console.WriteLine(medico);
        Console.WriteLine(paciente);
    }
}

enum Sexo
{
    Masculino,
    Feminino
}

class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

    public Pessoa(string nome, DateTime dataNascimento, string cpf)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = TratarCPF(cpf);
    }

    private string TratarCPF(string cpf)
    {
        return cpf;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Data de Nascimento: {DataNascimento.ToShortDateString()}, CPF: {CPF}";
    }
}

class Medico : Pessoa
{
    public string CRM { get; set; }

    public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
        : base(nome, dataNascimento, cpf)
    {
        CRM = crm;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, CRM: {CRM}";
    }
}

class Paciente : Pessoa
{
    public Sexo Sexo { get; set; }
    public string Sintomas { get; set; }

    public Paciente(string nome, DateTime dataNascimento, string cpf, Sexo sexo, string sintomas)
        : base(nome, dataNascimento, cpf)
    {
        Sexo = sexo;
        Sintomas = sintomas;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Sexo: {Sexo}, Sintomas: {Sintomas}";
    }
}
