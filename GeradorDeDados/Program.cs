using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using File;
using GeradorDeDados.Service;
using Model;

namespace GeradorDeDados
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            RunAsync().Wait();
        }

        public static async Task RunAsync()
        {
            var caminho = @"C:\Users\Junior\Desktop\dados.json";

            Console.WriteLine("Extraindo dados e adicionando no banco...");

            await AdicionarNoBanco(ReadFile.ExtrairDados(caminho));

            Console.WriteLine("Adicionado com sucesso");
        }

        public async static Task AdicionarNoBanco(List<Passagem> passagens)
        {
            foreach (var passagem in passagens)
                await AndreAirlinesApiService.CadadastrarVoo(passagem);
        }
    }
}
