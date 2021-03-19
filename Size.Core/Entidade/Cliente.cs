using System;

namespace ProjetoSize.Core
{
    public class Cliente
    {
        #region Atributos
        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public Documento Documento { get; private set; }
        #endregion


        #region Métodos
        public Cliente(string pNome, string pDocumento)
        {
            ValidarNome(pNome);
            Documento = new Documento(pDocumento);
        }

        public void ValidarNome(string pNome)
        {
            if (string.IsNullOrEmpty(pNome)) throw new Exception("Nome inválido");

        }

        #endregion
    }
}