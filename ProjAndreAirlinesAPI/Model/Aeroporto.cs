using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model
{
    public class Aeroporto
    {
        [Key]
        [JsonProperty("Sigla")]
        public string Sigla { get; set; }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("Endereco")]
        public virtual Endereco Endereco { get; set; }

        public Aeroporto() { }
    }
}
