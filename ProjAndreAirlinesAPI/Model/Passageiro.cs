using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProjAndreAirlinesAPI.Model
{
    public class Passageiro
    {
        [Key]
        [JsonProperty("Cpf")]
        public string Cpf { get; set; }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("DataNasc")]
        public DateTime DataNasc { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Telefone")]
        public string Telefone { get; set; }

        [JsonProperty("Endereco")]
        public virtual Endereco Endereco { get; set; }

        public Passageiro() { }
    }
}
