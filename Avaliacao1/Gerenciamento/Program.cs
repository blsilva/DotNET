using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Consultorio consultorio = new Consultorio();

        Medico medico1 = new Medico("Dr. José", new DateTime(1980, 1, 1), "12345678901", "CRM1234");
        Medico medico2 = new Medico("Dr. Ana", new DateTime(1985, 3, 15), "23456789012", "CRM5678");
        Medico medico3 = new Medico("Dr. Carlos", new DateTime(1975, 8, 5), "34567890123", "CRM9012");

        Paciente paciente1 = new Paciente("Maria", new DateTime(1990, 5, 10), "98765432109", Sexo.Feminino, "Febre");
        Paciente paciente2 = new Paciente("João", new DateTime(1988, 7, 20), "87654321098", Sexo.Masculino, "Dor de cabeça");
        Paciente paciente3 = new Paciente("Alice", new DateTime(1995, 9, 3), "76543210987", Sexo.Feminino, "Gripe");

        consultorio.CadastrarMedico(medico1);
        consultorio.CadastrarMedico(medico2);
        consultorio.CadastrarMedico(medico3);

        consultorio.CadastrarPaciente(paciente1);
        consultorio.CadastrarPaciente(paciente2);
        consultorio.CadastrarPaciente(paciente3);

        // Relatórios
        Console.WriteLine("Relatório 1: Médicos com idade entre dois valores");
        var medicoRelatorio1 = consultorio.ObterMedicosPorIdade(30, 50);
        foreach (var medico in medicoRelatorio1)
        {
            Console.WriteLine(medico);
        }
        Console.WriteLine();

        Console.WriteLine("Relatório 2: Pacientes com idade entre dois valores");
        var pacienteRelatorio2 = consultorio.ObterPacientesPorIdade(25, 35);
        foreach (var paciente in pacienteRelatorio2)
        {
            Console.WriteLine(paciente);
        }
        Console.WriteLine();

        Console.WriteLine("Relatório 3: Pacientes do sexo informado pelo usuário");
        var pacienteRelatorio3 = consultorio.ObterPacientesPorSexo(Sexo.Feminino);
        foreach (var paciente in pacienteRelatorio3)
        {
            Console.WriteLine(paciente);
        }
        Console.WriteLine();

        Console.WriteLine("Relatório 4: Pacientes em ordem alfabética");
        var pacienteRelatorio4 = consultorio.ObterPacientesEmOrdemAlfabetica();
        foreach (var paciente in pacienteRelatorio4)
        {
            Console.WriteLine(paciente);
        }
        Console.WriteLine();

        Console.WriteLine("Relatório 5: Pacientes cujos sintomas contenham texto informado pelo usuário");
        var pacienteRelatorio5 = consultorio.ObterPacientesPorSintomas("Dor");
        foreach (var paciente in pacienteRelatorio5)
        {
            Console.WriteLine(paciente);
        }
        Console.WriteLine();

        Console.WriteLine("Relatório 6: Médicos e Pacientes aniversariantes do mês informado (mês 5 no exemplo)");
        var aniversariantesRelatorio6 = consultorio.ObterAniversariantesDoMes(5);
        foreach (var pessoa in aniversariantesRelatorio6)
        {
            Console.WriteLine(pessoa);
        }
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
        if (!medicos.Any(m => m.CPF == medico.CPF) && !medicos.Any(m => m.CRM == medico.CRM))
        {
            medicos.Add(medico);
        }
        else
        {
            Console.WriteLine("Médico com CPF ou CRM duplicado. Cadastro não realizado.");
        }
    }

    public void CadastrarPaciente(Paciente paciente)
    {
        if (!pacientes.Any(p => p.CPF == paciente.CPF))
        {
            pacientes.Add(paciente);
        }
        else
        {
            Console.WriteLine("Paciente com CPF duplicado. Cadastro não realizado.");
        }
    }

    public List<Medico> ObterMedicosPorIdade(int idadeMinima, int idadeMaxima)
    {
        DateTime dataAtual = DateTime.Now;
        return medicos.Where(m => (dataAtual - m.DataNascimento).Days / 365 >= idadeMinima && (dataAtual - m.DataNascimento).Days / 365 <= idadeMaxima).ToList();
    }

    public List<Paciente> ObterPacientesPorIdade(int idadeMinima, int idadeMaxima)
    {
        DateTime dataAtual = DateTime.Now;
        return pacientes.Where(p => (dataAtual - p.DataNascimento).Days / 365 >= idadeMinima && (dataAtual - p.DataNascimento).Days / 365 <= idadeMaxima).ToList();
    }

    public List<Paciente> ObterPacientesPorSexo(Sexo sexo)
    {
        return pacientes.Where(p => p.Sexo == sexo).ToList();
    }

    public List<Paciente> ObterPacientesEmOrdemAlfabetica()
    {
        return pacientes.OrderBy(p => p.Nome).ToList();
    }

    public List<Paciente> ObterPacientesPorSintomas(string textoSintomas)
    {
        return pacientes.Where(p => p.Sintomas.Contains(textoSintomas)).ToList();
    }

    public List<Pessoa> ObterAniversariantesDoMes(int mes)
    {
        return medicos.Concat<Pessoa>(pacientes)
            .Where(p => p.DataNascimento.Month == mes)
            .OrderBy(p => p.DataNascimento.Day)
            .ToList();
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
