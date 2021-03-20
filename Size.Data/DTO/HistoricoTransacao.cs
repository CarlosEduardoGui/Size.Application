using Size.Data.Enums;
using System;

namespace Size.Data.DTO
{
    public class HistoricoTransacao
    {
        public Guid ID { get; set; }

        public double Valor { get; set; }

        public ETipoOperacao TipoOperacao { get; set; }

        public DateTime DataHora { get; set; }
    }
}
