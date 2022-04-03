using System;
using ProjAndreAirlinesAPI.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjAndreAirlinesAPI.Model
{
    public class Passagem
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        
        [JsonProperty("Voo")]
        public virtual Voo Voo { get; set; }
        
        [JsonProperty("Passageiro")]
        public virtual Passageiro Passageiro { get; set; }

        [JsonProperty("Classe")]
        public virtual Classe Classe { get; set; }

        [JsonProperty("Valor")]
        [Column(TypeName="decimal(10,2)")]
        public decimal Valor { get; set; }

        [JsonProperty("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        public Passagem() { }
    }
}
