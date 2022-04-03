using Newtonsoft.Json;

namespace Model
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
