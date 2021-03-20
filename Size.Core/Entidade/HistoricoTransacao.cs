using Size.Core.Enums;
using System;

namespace Size.Core.Entidade
{
    public class HistoricoTransacao
    {
        public HistoricoTransacao() { }

        public Guid ID { get; set; }

        public double Valor { get; set; }

        public ETipoOperacao TipoOperacao { get; set; }

        public DateTime DataHora { get; set; }

        public Conta Conta { get; set; }

    }
}
