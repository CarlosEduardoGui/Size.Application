using Size.Core.Entidade;
using Size.Core.Enums;
using Size.Core.Interface;
using System;
using System.Linq;

namespace Size.Business
{
    public class ClienteBLL : IOperacao
    {
        private readonly Cliente Cliente;

        private readonly IClienteRepository _clienteRepository;
        private readonly IContaRepository _contaRepository;

        public ClienteBLL(IClienteRepository clienteRepository,
            IContaRepository contaRepository,
            Cliente pCliente)
        {
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;

            Cliente = pCliente;
            Cliente.Conta = new Conta();
        }

        public void Executar()
        {
            if (Cliente == null) throw new Exception("Cliente inválido");

            Cliente.Documento.TipoDocumento = Documento.VerificarTipoDocumento(Cliente.Documento.Numero) == 11 ? ETipoDocumento.CPF : ETipoDocumento.CNPJ;

            Cliente.TipoCliente = Cliente.Documento.TipoDocumento.Equals(ETipoDocumento.CPF) ? ETipoCliente.PessoaFisica : ETipoCliente.PessoaJurifica;

            Cliente.Conta.NumeroConta = _contaRepository.ObterTodos().Count() != 0
                ? _contaRepository.ObterTodos().OrderByDescending(x => x.NumeroConta).Select(x => x.NumeroConta).FirstOrDefault() + 1
                : 1;

            Cliente.Conta.Valor = 0.00;

            _clienteRepository.Adicionar(Cliente);
        }
    }
}
