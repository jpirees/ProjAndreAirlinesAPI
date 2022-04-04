using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProjAndreAirlinesAPI.Model;
using Newtonsoft.Json;

namespace ProjAndreAirlinesAPI.Service
{
    public class ViaCepService
    {
        public static async Task<Endereco> ConsultarCep(string cep)
        {
            using var client = new HttpClient();

            try
            {
                client.BaseAddress = new System.Uri("https://viacep.com.br/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"ws/{cep}/json/");

                return await response.Content.ReadFromJsonAsync<Endereco>();
            }
            catch (HttpRequestException exception)
            {
                throw new HttpRequestException("Exception: " + exception.Message);
            }
        }
    }
}
