using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjAndreAirlinesAPI.Model
{
    public class Voo
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("OrigemSigla")]
        [ForeignKey("OrigemSigla")]
        public string OrigemSigla { get; set; }

        [JsonProperty("Origem")]
        public virtual Aeroporto Origem { get; set; }


        [JsonProperty("DestinoSigla")]
        [ForeignKey("DestinoSigla")]
        public string DestinoSigla { get; set; }

        [JsonProperty("Destino")]
        public virtual Aeroporto Destino { get; set; }

        [JsonProperty("AeronaveId")]
        [ForeignKey("AeronaveId")]
        public string AeronaveId { get; set; }

        [JsonProperty("Aeronave")]
        public virtual Aeronave Aeronave { get; set; }

        [JsonProperty("HorarioEmbarque")]
        public DateTime HorarioEmbarque { get; set; }

        [JsonProperty("HorarioDesembarque")]
        public DateTime HorarioDesembarque { get; set; }

        public Voo() { }

        public Voo(string origemSigla, string destinoSigla, string aeronaveId, DateTime horarioEmbarque, DateTime horarioDesembarque)
        {
            OrigemSigla = origemSigla;
            DestinoSigla = destinoSigla;
            AeronaveId = aeronaveId;
            HorarioEmbarque = horarioEmbarque;
            HorarioDesembarque = horarioDesembarque;
        }
    }
}
