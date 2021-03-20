using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Size.Core.Entidade
{
    public class Conta
    {
        [Key]
        [JsonIgnore]
        public Guid ID { get; set; }
        public int NumeroConta { get; set; }
        public double Valor { get; set; }

        public Conta() { ID = Guid.NewGuid(); }


    }
}
