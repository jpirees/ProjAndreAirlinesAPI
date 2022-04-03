using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjAndreAirlinesAPI.Model
{
    public class Aeronave
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("Capacidade")]
        public int Capacidade { get; set; }

        public Aeronave() { }
    }
}
