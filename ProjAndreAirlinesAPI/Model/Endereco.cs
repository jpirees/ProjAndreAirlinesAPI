﻿using Newtonsoft.Json;

namespace ProjAndreAirlinesAPI.Model
{
    public class Endereco
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Cep")]
        public string Cep { get; set; }

        [JsonProperty("Logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("Numero")]
        public int Numero { get; set; }

        [JsonProperty("Bairro")]
        public string Bairro { get; set; }

        [JsonProperty("Localidade")]
        public string Localidade { get; set; }

        [JsonProperty("Uf")]
        public string Uf { get; set; }

        [JsonProperty("Pais")]
        public string Pais { get; set; }

        [JsonProperty("Complemento")]
        public string Complemento { get; set; }

        public Endereco() { }

        public Endereco(string cep, int numero)
        {
            Cep = cep;
            Numero = numero;
        }
    }
}