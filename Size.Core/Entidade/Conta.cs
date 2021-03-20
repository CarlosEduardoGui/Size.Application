using Size.Core.Entidade;
using System;
using System.Collections.Generic;

namespace Size.Core.Entidade
{
    public class Conta
    {
        public Guid ID { get; private set; }
        public List<HistoricoTransacao> HistoricoTransacoes { get; private set; }


        private Conta() { }

        public static Conta NovaConta(Cliente pCliente)
        {
            if (pCliente == null) throw new ArgumentException("Cliente precisa ser preenchido");

            return new Conta
            {
                ID = Guid.NewGuid(),
                HistoricoTransacoes = new List<HistoricoTransacao>()
            };
        }

        public static string FazerDeposito(double pValor)
        {
            if (!ValidarDeposito(pValor)) return "Valor inválido.";


            return "Valor Depositado com sucesso!";
        }

        public static string FazerSaque(double pValor)
        {
            if (!ValidarValor(pValor)) return "Valor inválido.";

            return "Valor Depositado com sucesso!";
        }

        public static string FazerTransferencia(double pValor)
        {
            if (!ValidarValor(pValor)) return "Valor inválido.";

            return "Valor Depositado com sucesso!";
        }

        private static bool ValidarDeposito(double pValor)
        {
            return ValidarValor(pValor);
        }

        private static bool ValidarValor(double pValor)
        {
            return pValor >= 0;
        }
    }
}
