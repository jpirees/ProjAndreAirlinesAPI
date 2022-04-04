using System;
using Newtonsoft.Json;

namespace ProjAndreAirlinesAPI.DTO
{
    public class VooDTO
    {
        internal readonly int Id;

        [JsonProperty("Origem")]
        public string OrigemSigla { get; set; }

        [JsonProperty("Destino")]
        public string DestinoSigla { get; set; }

        [JsonProperty("Aeronave")]
        public string AeronaveId { get; set; }

        [JsonProperty("HorarioEmbarque")]
        public DateTime HorarioEmbarque { get; set; }

        [JsonProperty("HorarioDesembarque")]
        public DateTime HorarioDesembarque { get; set; }
    }
}
