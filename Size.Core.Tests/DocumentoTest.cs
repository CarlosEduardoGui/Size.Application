using ProjetoSize.Core;
using System;
using Xunit;

namespace Size.Core.Tests
{
    public class DocumentoTest
    {
        [Fact]
        public void ValidarInstancia()
        {
            var lDocumentoMoq = "47540018852";
            var lDocumento = new Documento(lDocumentoMoq);

            Assert.NotNull(lDocumento);
        }
    }
}
