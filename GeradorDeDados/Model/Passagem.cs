using System;
using Newtonsoft.Json;

namespace Model
{
    public class Passagem
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        
        [JsonProperty("Voo")]
        public Voo Voo { get; set; }
        
        [JsonProperty("Passageiro")]
        public Passageiro Passageiro { get; set; }

        [JsonProperty("Classe")]
        public Classe Classe { get; set; }

        [JsonProperty("Valor")]
        public decimal Valor { get; set; }

        [JsonProperty("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        public Passagem() { }
    }
}
