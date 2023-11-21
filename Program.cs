using System;
using System.Collections.Generic;
using System.Linq;

class Programa
{
    static List<TarefaItem> tarefas = new List<TarefaItem>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas Pendentes");
            Console.WriteLine("5. Listar Tarefas Concluídas");
            Console.WriteLine("6. Excluir Tarefa");
            Console.WriteLine("7. Pesquisar Tarefas por Palavra-Chave");
            Console.WriteLine("8. Exibir Estatísticas");
            Console.WriteLine("9. Sair");

            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    CriarTarefa();
                    break;
                case "2":
                    ListarTarefas();
                    break;
                case "3":
                    MarcarTarefaComoConcluida();
                    break;
                case "4":
                    ListarTarefasPendentes();
                    break;
                case "5":
                    ListarTarefasConcluidas();
                    break;
                case "6":
                    ExcluirTarefa();
                    break;
                case "7":
                    PesquisarTarefas();
                    break;
                case "8":
                    ExibirEstatisticas();
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CriarTarefa()
    {
        Console.Write("Digite o título da tarefa: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite a data de vencimento (dd/mm/yyyy): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataVencimento))
        {
            TarefaItem novaTarefa = new TarefaItem(titulo, descricao, dataVencimento);
            tarefas.Add(novaTarefa);

            Console.WriteLine("Tarefa criada com sucesso!");
        }
        else
        {
            Console.WriteLine("Formato de data inválido. Tarefa não criada.");
        }
    }

    static void ListarTarefas()
    {
        Console.WriteLine("Lista de Tarefas:");
        foreach (var tarefa in tarefas)
        {
            Console.WriteLine(tarefa);
        }
    }

    static void MarcarTarefaComoConcluida()
    {
        Console.Write("Digite o número da tarefa concluída: ");
        if (int.TryParse(Console.ReadLine(), out int numeroTarefa) && numeroTarefa >= 1 && numeroTarefa <= tarefas.Count)
        {
            tarefas[numeroTarefa - 1].EstaConcluida = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido. Tarefa não marcada como concluída.");
        }
    }

    static void ListarTarefasPendentes()
    {
        var tarefasPendentes = tarefas.Where(t => !t.EstaConcluida).ToList();
        Console.WriteLine("Tarefas Pendentes:");
        foreach (var tarefa in tarefasPendentes)
        {
            Console.WriteLine(tarefa);
        }
    }

    static void ListarTarefasConcluidas()
    {
        var tarefasConcluidas = tarefas.Where(t => t.EstaConcluida).ToList();
        Console.WriteLine("Tarefas Concluídas:");
        foreach (var tarefa in tarefasConcluidas)
        {
            Console.WriteLine(tarefa);
        }
    }

    static void ExcluirTarefa()
    {
        Console.Write("Digite o número da tarefa a ser excluída: ");
        if (int.TryParse(Console.ReadLine(), out int numeroTarefa) && numeroTarefa >= 1 && numeroTarefa <= tarefas.Count)
        {
            tarefas.RemoveAt(numeroTarefa - 1);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido. Tarefa não excluída.");
        }
    }

    static void PesquisarTarefas()
    {
        Console.Write("Digite a palavra-chave para pesquisar: ");
        string palavraChave = Console.ReadLine();

        var tarefasEncontradas = tarefas.Where(t => t.Titulo.Contains(palavraChave) || t.Descricao.Contains(palavraChave)).ToList();

        Console.WriteLine("Tarefas Encontradas:");
        foreach (var tarefa in tarefasEncontradas)
        {
            Console.WriteLine(tarefa);
        }
    }

    static void ExibirEstatisticas()
    {
        int totalTarefas = tarefas.Count;
        int tarefasConcluidas = tarefas.Count(t => t.EstaConcluida);
        int tarefasPendentes = totalTarefas - tarefasConcluidas;

        var tarefaMaisAntiga = tarefas.OrderBy(t => t.DataVencimento).FirstOrDefault();
        var tarefaMaisRecente = tarefas.OrderByDescending(t => t.DataVencimento).FirstOrDefault();

        Console.WriteLine($"Total de Tarefas: {totalTarefas}");
        Console.WriteLine($"Tarefas Concluídas: {tarefasConcluidas}");
        Console.WriteLine($"Tarefas Pendentes: {tarefasPendentes}");
        Console.WriteLine($"Tarefa mais antiga: {tarefaMaisAntiga}");
        Console.WriteLine($"Tarefa mais recente: {tarefaMaisRecente}");
    }
}

class TarefaItem
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool EstaConcluida { get; set; }

    public TarefaItem(string titulo, string descricao, DateTime dataVencimento)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataVencimento = dataVencimento;
        EstaConcluida = false;
    }

    public override string ToString()
    {
        return $"{Titulo} - {Descricao} - Data de Vencimento: {DataVencimento.ToString("dd/MM/yyyy")} - {(EstaConcluida ? "Concluída" : "Pendente")}";
    }
}

