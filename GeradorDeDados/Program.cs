using System;
using System.Globalization;
using GeradorDeDados.Service;

namespace GeradorDeDados
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            string opcao;

            do
            {
                switch (opcao = Menu())
                {
                    case "0": break;

                    case "1":
                        Console.Clear();
                        break;

                    case "2":
                        GerarRelatorios();
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

            } while (opcao != "0");
        }

        private static void GerarRelatorios()
        {
            string opcao;

            do
            {
                switch (opcao = OpcoesRelatorios())
                {
                    case "0":
                        Environment.Exit(0);
                        break;

                    case "1":
                        Console.Clear();
                        Console.WriteLine("Relatório indisponível.");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Informe um mês de 1 a 12");
                        _ = int.TryParse(Console.ReadLine(), out int mes);

                        Console.Clear();

                        Console.WriteLine($"Gerando relatório do mês {mes}");
                        _ = AndreAirlinesApiService.GerarRelatorioPassagens(mes);
                        Console.WriteLine("Relatório gerado.");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }


            } while (opcao != "0");

            return;
        }
        
        public static string Menu()
        {
            Console.Clear();
            Console.WriteLine("---------- Menu ----------");
            Console.WriteLine("1. Extrair dados");
            Console.WriteLine("2. Relatórios");
            Console.WriteLine("0. Relatórios");

            return Console.ReadLine();
        }

        private static string OpcoesRelatorios()
        {
            Console.Clear();
            Console.WriteLine("1. Relatório de Preços Bases");
            Console.WriteLine("2. Relatório de Passagens");
            Console.WriteLine("0. Voltar");

            return Console.ReadLine();
        }

    }
}
