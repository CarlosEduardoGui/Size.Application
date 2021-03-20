using Size.Core.Entidade;
using Size.Core.Enums;
using Size.Core.Interface;
using System;

namespace Size.Business
{
    public class DepositoBLL : IOperacao
    {
        private readonly Conta Conta;

        private readonly IContaRepository _contaRepository;

        public DepositoBLL(IContaRepository contaRepository, Conta pConta)
        {
            Conta = pConta;
            _contaRepository = contaRepository;
        }


        public void Executar()
        {
            if (Conta != null)
            {
                _contaRepository.Atualizar(Conta);
                
                var lHistorico = new HistoricoTransacao
                {
                    Conta = _contaRepository.ObterPorId(Conta.ID),
                    TipoOperacao = ETipoOperacao.Deposito,
                };



            }
        }
    }
}
