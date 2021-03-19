using Size.Core.Enums;
using System;

namespace ProjetoSize.Core
{
    public class Documento
    {
        public ETipoDocumento TipoDocumento { get; private set; }


        public Documento(string pDocumento)
        {
            VerificarTipoDocumento(pDocumento);
        }

        public void ValidarDocumento(string pDocumento)
        {
            if (string.IsNullOrEmpty(pDocumento)) throw new Exception("Documento inválido");
        }

        public void VerificarTipoDocumento(string pTipoDocumento)
        {
            ValidarDocumento(pTipoDocumento);
        }
    }
}
