using System;
using System.Collections.Generic;

class Program
{
    static Stack<string> tarefasPendentes = new Stack<string>();
    static Stack<string> tarefasConcluidas = new Stack<string>();

    static void Main(string[] args)
    {
        string opcao;

        do
        {
            Console.WriteLine("\n~~~ Gerenciamento de Tarefas ~~~");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Visualizar Tarefas Pendentes");
            Console.WriteLine("3. Concluir Tarefa");
            Console.WriteLine("4. Desfazer Tarefa Concluída");
            Console.WriteLine("5. Sair");
            Console.Write("~~~ Escolha uma opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarTarefa();
                    break;
                case "2":
                    VisualizarTarefasPendentes();
                    break;
                case "3":
                    ConcluirTarefa();
                    break;
                case "4":
                    DesfazerTarefaConcluída();
                    break;
                case "5":
                    Console.WriteLine("Obrigado por usar esse programa");
                    break;
                default:
                    Console.WriteLine("Saindo...");
                    break;
            }

        } while (opcao != "5");
    }

    static void AdicionarTarefa()
    {
        Console.Write("Descrição da tarefa: ");
        string tarefa = Console.ReadLine();
        tarefasPendentes.Push(tarefa);
        Console.WriteLine("Tarefa adicionada com sucesso");
    }

    static void VisualizarTarefasPendentes()
    {
        Console.WriteLine("\n~~~ Tarefas Pendentes ~~~");

        if (tarefasPendentes.Count == 0)
        {
            Console.WriteLine("Nenhuma pendencia");
        }
        else
        {
            foreach (var tarefa in tarefasPendentes)
            {
                Console.WriteLine(tarefa);
            }
        }
    }

    static void ConcluirTarefa()
    {
        if (tarefasPendentes.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa para concluir.");
        }
        else
        {
            string tarefaConcluida = tarefasPendentes.Pop();
            tarefasConcluidas.Push(tarefaConcluida);
            Console.WriteLine($"Tarefa '{tarefaConcluida}' concluída.");
        }
    }

    static void DesfazerTarefaConcluída()
    {
        if (tarefasConcluidas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa concluída para desfazer.");
        }
        else
        {
            string tarefaDesfeita = tarefasConcluidas.Pop();
            tarefasPendentes.Push(tarefaDesfeita);
            Console.WriteLine($"Tarefa '{tarefaDesfeita}' desfeita e adicionada novamente às tarefas pendentes.");
        }
    }
}
