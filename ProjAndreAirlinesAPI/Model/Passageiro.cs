using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Model
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

        public Passageiro(string cpf, string nome, DateTime dataNasc, string email, string telefone, Endereco endereco)
        {
            Cpf = cpf;
            Nome = nome;
            DataNasc = dataNasc;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
