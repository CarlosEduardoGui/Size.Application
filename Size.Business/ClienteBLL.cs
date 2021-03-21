using Size.Core.Entidade;
using Size.Core.Enums;
using Size.Core.Interface;
using System;

namespace Size.Business
{
    public class ClienteBLL : IOperacao
    {
        private readonly Cliente Cliente;
        private readonly IClienteRepository _clienteRepository;

        public ClienteBLL(IClienteRepository clienteRepository, Cliente pCliente)
        {
            _clienteRepository = clienteRepository;
            Cliente = pCliente;
        }

        public void Executar()
        {
            if (Cliente == null) throw new Exception("Cliente inválido");

            //if (Documento.ValidarDocumento(Cliente.Documento.Numero)) throw;

            Cliente.Documento.TipoDocumento = Documento.VerificarTipoDocumento(Cliente.Documento.Numero) == 11 ? ETipoDocumento.CPF : ETipoDocumento.CNPJ;

            Cliente.TipoCliente = Cliente.Documento.TipoDocumento.Equals(ETipoDocumento.CPF) ? ETipoCliente.PessoaFisica : ETipoCliente.PessoaJurifica;

            _clienteRepository.Adicionar(Cliente);
        }


        //public int CriarNumeroConta()
        //{
        //    return _clienterepository
        //}
    }
}
