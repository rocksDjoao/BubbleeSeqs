using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // criação de uma arraylist em ordem inversa
        List<int> numeros = new List<int>();


        for (int i = 10000; i >= 1; i--)
        {
            numeros.Add(i);
        }


        for (int i = 0; i < 10; i++)
        {
            Console.Write(numeros[i] + " ");
        }


        for (int i = numeros.Count - 10; i < numeros.Count; i++)
        {
            Console.Write(numeros[i] + " ");
        }

        // Conversão de arrylista para array
        int[] vet = numeros.ToArray();

        // Medição d tempo de execução do Bubble Sort
        Console.WriteLine("\n\n=== INICIANDO BUBBLE SORT ===");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Algoritmo do Bubble Sort :)
        int aux = 0;
        bool trocou;
        for (int i = 0; i < vet.Length - 1; i++)
        {
            trocou = false;
            for (int j = 0; j < vet.Length - 1 - i; j++)
            {
                if (vet[j] > vet[j + 1])
                {
                    aux = vet[j];
                    vet[j] = vet[j + 1];
                    vet[j + 1] = aux;
                    trocou = true;
                }
            }

            if (!trocou) break;
        }

        stopwatch.Stop();
        Console.WriteLine($"Bubble Sort concluído em: {stopwatch.ElapsedMilliseconds} ms");

        // Mostrar resultados da ordenação
        Console.WriteLine("\nPrimeiros 10 elementos (após ordenação):");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(vet[i] + " ");
        }

        Console.WriteLine("\n\nÚltimos 10 elementos (após ordenação):");
        for (int i = vet.Length - 10; i < vet.Length; i++)
        {
            Console.Write(vet[i] + " ");
        }

        // Busca sequencial no array ordenado
        Console.WriteLine("\n\n=== BUSCA SEQUENCIAL NO VETOR ORDENADO ===");

        bool continuar = true;
        while (continuar)
        {
            Console.Write("\nDigite um valor para buscar valores de (1-10000) para ver qual posição o número escolhido vai estar ou 'sair' para encerrar: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "sair")
            {
                continuar = false;
                continue;
            }

            if (int.TryParse(input, out int valorBusca))
            {
                if (valorBusca < 1 || valorBusca > 10000)
                {
                    Console.WriteLine("Valor deve estar entre 1 e 10000!");
                    continue;
                }

                Stopwatch stopwatchBusca = new Stopwatch();
                stopwatchBusca.Start();

                int posicao = BuscaSequencial(vet, valorBusca);

                stopwatchBusca.Stop();

                if (posicao != -1)
                {
                    Console.WriteLine($"Valor {valorBusca} encontrado na posição {posicao}.");
                    Console.WriteLine($"Tempo de busca: {stopwatchBusca.ElapsedTicks} ticks");

                    // Verificar se está na posição correta (já que o array está ordenado)
                    if (vet[posicao] == valorBusca)
                    {
                        Console.WriteLine("✓ Posição validada com sucesso!");
                    }
                }
                else
                {
                    Console.WriteLine($"Valor {valorBusca} não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido!");
            }
        }

        Console.WriteLine("\nPrograma encerrado!");
    }

    // Método de busca sequencial
    public static int BuscaSequencial(int[] vetor, int valor)
    {
        for (int i = 0; i < vetor.Length; i++)
        {
            if (valor == vetor[i])
            {
                return i;
            }
        }
        return -1;
    }
}