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
            Console.WriteLine("Extraindo e adicionando dados...");

            var pathFile = @"C:\Users\Junior\Desktop\testes.json";
            await AdicionarVoos(ReadFile.ExtrairDados(pathFile));

            Console.WriteLine("Adicionado com sucesso");
        }

        public async static Task AdicionarVoos(List<Voo> voos)
        {
            foreach (var voo in voos)
                await AndreAirlinesApiService.CadadastrarVoo(voo);
        }
    }
}
