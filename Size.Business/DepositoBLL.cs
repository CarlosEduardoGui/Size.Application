using Size.Core.Entidade;
using Size.Core.Enums;
using Size.Core.Interface;

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
                _contaRepository.Atualizar(Conta);

                var lHistorico = new HistoricoTransacao
                {
                    Conta = _contaRepository.ObterPorId(Conta.ID),
                    TipoOperacao = ETipoOperacao.Deposito,
                };

                _historicoTransacaoRepository.Adicionar(lHistorico);
            }
        }
    }
}
