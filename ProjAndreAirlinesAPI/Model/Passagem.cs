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

        [JsonProperty("VooId")]
        [ForeignKey("VooId")]
        public int VooId { get; set; }

        [JsonProperty("Voo")]
        public virtual Voo Voo { get; set; }

        [JsonProperty("PassageiroCpf")]
        [ForeignKey("PassageiroCpf")]
        public string PassageiroCpf { get; set; }

        [JsonProperty("Passageiro")]
        public virtual Passageiro Passageiro { get; set; }

        [JsonProperty("ClasseId")]
        [ForeignKey("ClasseId")]
        public int ClasseId { get; set; }

        [JsonProperty("Classe")]
        public virtual Classe Classe { get; set; }

        [JsonProperty("Valor")]
        [Column(TypeName="decimal(10,2)")]
        public decimal Valor { get; set; }

        [JsonProperty("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        public Passagem() { }

        public Passagem(int vooId, string passageiroCpf, int classeId, decimal valor, DateTime dataCadastro)
        {
            VooId = vooId;
            PassageiroCpf = passageiroCpf;
            ClasseId = classeId;
            Valor = valor;
            DataCadastro = dataCadastro;
        }
    }
}
