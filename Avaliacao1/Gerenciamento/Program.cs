using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Medico medico = new Medico("Dr. José", new DateTime(1980, 1, 1), "12345678901", "CRM1234");
        Paciente paciente = new Paciente("Maria", new DateTime(1990, 5, 10), "98765432109", Sexo.Feminino, "Febre");

        Consultorio consultorio = new Consultorio();
        consultorio.CadastrarMedico(medico);
        consultorio.CadastrarPaciente(paciente);

        consultorio.GerarRelatorioMedicos();
        consultorio.GerarRelatorioPacientes();
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
}

class Medico : Pessoa
{
    public string CRM { get; set; }

    public Medico(string nome, DateTime dataNascimento, string cpf, string crm)
        : base(nome, dataNascimento, cpf)
    {
        CRM = crm;
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
}

class Consultorio
{
    private List<Medico> medicos;
    private List<Paciente> pacientes;

    public Consultorio()
    {
        medicos = new List<Medico>();
        pacientes = new List<Paciente>();
    }

    public void CadastrarMedico(Medico medico)
    {
        medicos.Add(medico);
    }

    public void CadastrarPaciente(Paciente paciente)
    {
        pacientes.Add(paciente);
    }

    public void GerarRelatorioMedicos()
    {
        Console.WriteLine("Relatório de Médicos:");
        foreach (var medico in medicos)
        {
            Console.WriteLine($"Nome: {medico.Nome}, CRM: {medico.CRM}");
        }
        Console.WriteLine();
    }

    public void GerarRelatorioPacientes()
    {
        Console.WriteLine("Relatório de Pacientes:");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine($"Nome: {paciente.Nome}, Sexo: {paciente.Sexo}, Sintomas: {paciente.Sintomas}");
        }
        Console.WriteLine();
    }
}
