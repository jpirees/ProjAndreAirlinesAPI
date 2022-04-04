using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ProjAndreAirlinesAPI.DTO
{
    public class PassagemDTO
    {
        internal readonly int Id;

        [JsonProperty("VooId")]
        public int VooId { get; set; }

        [JsonProperty("PassageiroCpf")]
        public string PassageiroCpf { get; set; }

        [JsonProperty("ClasseId")]
        public int ClasseId { get; set; }

        [JsonProperty("Valor")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [JsonProperty("DataCadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
