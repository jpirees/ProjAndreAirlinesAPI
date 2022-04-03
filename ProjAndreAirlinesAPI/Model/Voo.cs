using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [JsonProperty("Origem")]
        public virtual Aeroporto Origem { get; set; }

        [JsonProperty("Destino")]
        public virtual Aeroporto Destino { get; set; }

        [JsonProperty("Aeronave")]
        public virtual Aeronave Aeronave { get; set; }

        [JsonProperty("HorarioEmbarque")]
        public DateTime HorarioEmbarque { get; set; }

        [JsonProperty("HorarioDesembarque")]
        public DateTime HorarioDesembarque { get; set; }

        public Voo() { }

    }
}
