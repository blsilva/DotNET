using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Consultorio consultorio = new Consultorio();

        Medico medico1 = new Medico("Dr. José", new DateTime(1980, 1, 1), "12345678901", "CRM1234");
        Medico medico2 = new Medico("Dr. Ana", new DateTime(1985, 3, 15), "23456789012", "CRM1234"); // Médico com CRM duplicado
        Medico medico3 = new Medico("Dr. Carlos", new DateTime(1975, 8, 5), "34567890123", "CRM5678");

        Paciente paciente1 = new Paciente("Maria", new DateTime(1990, 5, 10), "98765432109", Sexo.Feminino);
        Paciente paciente2 = new Paciente("João", new DateTime(1988, 7, 20), "98765432109", Sexo.Masculino); // Paciente com CPF duplicado

        consultorio.CadastrarMedico(medico1);
        consultorio.CadastrarMedico(medico2);
        consultorio.CadastrarMedico(medico3);

        consultorio.CadastrarPaciente(paciente1);
        consultorio.CadastrarPaciente(paciente2);

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

    public Paciente(string nome, DateTime dataNascimento, string cpf, Sexo sexo)
        : base(nome, dataNascimento, cpf)
    {
        Sexo = sexo;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Sexo: {Sexo}";
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
        if (medicos.Any(m => m.CPF == medico.CPF))
        {
            Console.WriteLine($"Médico com CPF {medico.CPF} já cadastrado. Cadastro não realizado.");
        }
        else if (medicos.Any(m => m.CRM == medico.CRM))
        {
            Console.WriteLine($"Médico com CRM {medico.CRM} já cadastrado. Cadastro não realizado.");
        }
        else
        {
            medicos.Add(medico);
            Console.WriteLine($"Médico {medico.Nome} cadastrado com sucesso.");
        }
    }

    public void CadastrarPaciente(Paciente paciente)
    {
        if (pacientes.Any(p => p.CPF == paciente.CPF))
        {
            Console.WriteLine($"Paciente com CPF {paciente.CPF} já cadastrado. Cadastro não realizado.");
        }
        else
        {
            pacientes.Add(paciente);
            Console.WriteLine($"Paciente {paciente.Nome} cadastrado com sucesso.");
        }
    }

    public void GerarRelatorioMedicos()
    {
        Console.WriteLine("Relatório de Médicos:");
        foreach (var medico in medicos)
        {
            Console.WriteLine(medico);
        }
        Console.WriteLine();
    }

    public void GerarRelatorioPacientes()
    {
        Console.WriteLine("Relatório de Pacientes:");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine(paciente);
        }
        Console.WriteLine();
    }
}
