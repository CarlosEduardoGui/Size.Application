using Size.Core.Entidade;
using Size.Core.Interface;
using System;

namespace Size.Business
{
    public class DepositoBLL : IOperacao
    {
        private Conta Conta { get; set; }
        private double Valor { get; set; }


        public DepositoBLL(Conta pConta, double pValor)
        {
            Conta = pConta;
            Valor = pValor;
        }


        public void Executar()
        {
            if (Conta != null || Valor != 0)
            {
                throw new Exception("Dados invalidos.");
            }
        }
    }
}
