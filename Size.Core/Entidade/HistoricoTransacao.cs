using Size.Core.Enums;
using System;

namespace Size.Core.Entidade
{
    public class HistoricoTransacao
    {
        public Guid ID { get; private set; }

        public double Valor { get; private set; }

        public ETipoOperacao TipoOperacao { get; private set; }

        public DateTime DataHora { get; private set; }

        private HistoricoTransacao() { }

        public static HistoricoTransacao NovoHistoricoTransacao(double pValor, ETipoOperacao pTipoOperacao, DateTime pDataHoraOperacao)
        {

            if (pValor <= 0) throw new ArgumentException("Valor inválido.");
            if (pDataHoraOperacao < DateTime.Now) throw new ArgumentException("Data e hora inválido.");

            return new HistoricoTransacao
            {
                ID = Guid.NewGuid(),
                Valor = pValor,
                TipoOperacao = pTipoOperacao,
                DataHora = pDataHoraOperacao
            };
        }
    }
}
