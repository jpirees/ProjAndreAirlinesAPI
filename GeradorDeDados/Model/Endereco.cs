using Newtonsoft.Json;

namespace Model
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
        public string Numero { get; set; }

        [JsonProperty("Bairro")]
        public string Bairro { get; set; }

        [JsonProperty("Localidade")]
        public string Localidade { get; set; }

        [JsonProperty("Estado")]
        public string Estado { get; set; }

        [JsonProperty("Pais")]
        public string Pais { get; set; }

        [JsonProperty("Complemento")]
        public string Complemento { get; set; }

        public Endereco() { }


        public override string ToString()
        {
            return $"{Cep} {Logradouro} {Numero} {Bairro} {Localidade} {Estado} {Pais} {Complemento}";
        }
    }
}