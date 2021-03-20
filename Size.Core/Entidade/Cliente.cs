using Size.Core.Entidade;
using Size.Core.Enums;
using System;

namespace Size.Core.Entidade
{
    public class Cliente
    {
        #region Atributos
        public Guid Id { get; set; }

        public string Nome { get; private set; }

        public Documento Documento { get; private set; }

        public ETipoCliente TipoCliente { get; private set; }

        public Conta Conta { get; private set; }
        #endregion


        #region Métodos
        private Cliente() { }

        public static Cliente NovoCliente(string pNome, string pDocumento)
        {
            if (string.IsNullOrEmpty(pNome)) throw new FormatException("Nome inválido.");
            if (string.IsNullOrEmpty(pDocumento)) throw new FormatException("Documento inválido.");

            return new Cliente
            {
                Id = Guid.NewGuid(),
                Documento = Documento.NovoDocumento(pDocumento),
                TipoCliente = pDocumento.Length == 11 ? ETipoCliente.PessoaFisica : ETipoCliente.PessoaJurifica
            };
        }

        #endregion
    }
}