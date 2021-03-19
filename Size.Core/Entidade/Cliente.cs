using Size.Core.Enums;
using System;

namespace ProjetoSize.Core
{
    public class Cliente
    {
        #region Atributos
        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public Documento Documento { get; private set; }

        public ETipoCliente TipoCliente { get; private set; }
        #endregion


        #region Métodos
        public Cliente(string pNome, string pDocumento)
        {
            ValidarNome(pNome);
            Documento = new Documento(pDocumento);
            TipoCliente = Documento.TipoDocumento.Equals(ETipoDocumento.CPF) ? ETipoCliente.PessoaFisica : ETipoCliente.PessoaJurifica;
        }

        public static void ValidarNome(string pNome)
        {
            if (string.IsNullOrEmpty(pNome)) throw new Exception("Nome inválido");
        }

        #endregion
    }
}