// See https://aka.ms/new-console-template for more information

using System;

// Esqueleto inicial (TP1) - Sistema de Biblioteca Universitária
// Paradigma procedural: apenas variáveis primitivas, operadores e controle de fluxo

string nomeMembro = "Estevão Sirqueira";
int emprestimosAtivos = 2; // Limite máximo: 3
string tituloLivro = "Engenharia de Software";
int exemplaresDisponiveis = 1;

const int PRAZO_DIAS = 14;
const int LIMITE_EMPRESTIMOS = 3;
const double MULTA_POR_DIA = 2.50;

int opcao = -1;

while (opcao != 0)
{
    Console.WriteLine("\n=== BIBLIOTECA UNIVERSITÁRIA ===");
    Console.WriteLine($"Membro: {nomeMembro} | Empréstimos ativos: {emprestimosAtivos}/{LIMITE_EMPRESTIMOS}");
    Console.WriteLine($"Livro: {tituloLivro} | Disponíveis: {exemplaresDisponiveis}");
    Console.WriteLine("1 - Registrar Empréstimo");
    Console.WriteLine("2 - Registrar Devolução");
    Console.WriteLine("0 - Sair");
    Console.Write("Opção: ");

    opcao = int.Parse(Console.ReadLine() ?? "0");

    if (opcao == 1)
    {
        if (emprestimosAtivos >= LIMITE_EMPRESTIMOS)
        {
            Console.WriteLine("Empréstimo negado: limite de 3 empréstimos atingido.");
        }
        else if (exemplaresDisponiveis <= 0)
        {
            Console.WriteLine("Empréstimo negado: nenhum exemplar disponível.");
        }
        else
        {
            emprestimosAtivos++;
            exemplaresDisponiveis--;
            Console.WriteLine($"Empréstimo aprovado! Prazo de devolução: {PRAZO_DIAS} dias corridos.");
        }
    }
    else if (opcao == 2)
    {
        if (emprestimosAtivos <= 0)
        {
            Console.WriteLine("Não há empréstimos ativos para devolver.");
        }
        else
        {
            Console.Write("Quantos dias se passaram desde a retirada? ");
            int diasPassados = int.Parse(Console.ReadLine() ?? "0");

            emprestimosAtivos--;
            exemplaresDisponiveis++;

            if (diasPassados > PRAZO_DIAS)
            {
                int diasAtraso = diasPassados - PRAZO_DIAS;
                double valorMulta = diasAtraso * MULTA_POR_DIA;
                Console.WriteLine($"Devolução com {diasAtraso} dia(s) de atraso. Multa: R$ {valorMulta:F2}");
            }
            else
            {
                Console.WriteLine("Devolução realizada dentro do prazo. Sem multa.");
            }
        }
    }
    else if (opcao != 0)
    {
        Console.WriteLine("Opção inválida.");
    }
}

Console.WriteLine("Sistema encerrado.");
