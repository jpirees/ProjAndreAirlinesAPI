using System;
using Newtonsoft.Json;

namespace Model
{
    public class Passageiro
    {
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
