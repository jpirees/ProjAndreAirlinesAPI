using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace GeradorDeDados.Service
{
    internal class AndreAirlinesApiService
    {
        public static async Task GerarRelatorioPassagens(int mes)
        {
            using var httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44374/api/Passagens");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var passagens = JsonConvert.DeserializeObject<List<Passagem>>(responseBody);

                var passagensQuery =
                    (from passagem in passagens
                     where passagem.DataCadastro.Month.Equals(mes)
                     select passagem);

                var passagensJson = JsonConvert.SerializeObject(passagensQuery, Formatting.Indented);

                if (!Directory.Exists("Relatorios"))
                    Directory.CreateDirectory("Relatorios");

                StreamWriter sw = new(@"Relatorios\RelatorioPassagem.json");
                sw.WriteLine(passagensJson);
                sw.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Exception: " + exception.Message);
            }
        }
    }
}
