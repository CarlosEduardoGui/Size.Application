using Size.Core.Entidade;
using Size.Core.Enums;
using Size.Core.Interface;
using System;
using System.Linq;

namespace Size.Business
{
    public class DepositoBLL : IOperacao
    {
        private readonly Conta Conta;

        private readonly IContaRepository _contaRepository;
        private readonly IHistoricoTransacaoRepository _historicoTransacaoRepository;

        public DepositoBLL(IContaRepository contaRepository,
            IHistoricoTransacaoRepository historicoTransacaoRepository,
            Conta pConta)
        {
            Conta = pConta;
            _contaRepository = contaRepository;
            _historicoTransacaoRepository = historicoTransacaoRepository;
        }


        public void Executar()
        {
            if (Conta != null)
            {
                if (Conta.Valor != 0)
                {
                    var lConta = _contaRepository.Buscar(x => x.NumeroConta == Conta.NumeroConta).First();
                    if (lConta != null)
                    {
                        lConta.Valor += Conta.Valor;

                        _contaRepository.Atualizar(lConta);

                        var lHistorico = new HistoricoTransacao
                        {
                            Conta = _contaRepository.ObterPorId(Conta.ID),
                            TipoOperacao = ETipoOperacao.Deposito,
                        };

                        _historicoTransacaoRepository.Adicionar(lHistorico);
                    }
                    else
                    {
                        throw new Exception("Conta informada não existe.");
                    }
                }
                else
                {
                    throw new Exception("Valor de deposito precisar ser mais que R$ 0.00");
                }
            }
            else
            {
                throw new Exception("Conta inválida.");
            }
        }
    }
}
