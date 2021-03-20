using Size.Core.Entidade;
using Xunit;

namespace Size.Core.Tests
{
    public class DocumentoTest
    {
        [Fact]
        public void ValidarInstancia()
        {
            var lDocumentoMoq = "47540018852";
            var lDocumento = Documento.NovoDocumento(lDocumentoMoq);

            Assert.NotNull(lDocumento);
        }
    }
}
