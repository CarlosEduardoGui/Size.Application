using Size.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Size.Core.Entidade
{
    public class HistoricoTransacao
    {
        [JsonIgnore]
        [Key]
        public Guid ID { get; set; }
        [JsonIgnore]
        public double Valor { get; set; }
        [JsonIgnore]
        public ETipoOperacao TipoOperacao { get; set; }
        [JsonIgnore]
        public DateTime DataHora { get; set; }
        [JsonIgnore]
        public Conta Conta { get; set; }

        public HistoricoTransacao() { }
    }
}
