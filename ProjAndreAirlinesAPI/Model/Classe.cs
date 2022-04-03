using Newtonsoft.Json;

namespace ProjAndreAirlinesAPI.Model
{
    public class Classe
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Descricao")]
        public string Descricao { get; set; }

        public Classe() { }
    }
}
