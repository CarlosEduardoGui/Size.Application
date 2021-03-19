using ProjetoSize.Core;
using Size.Core.Enums;
using System;
using Xunit;

namespace Size.Core.Tests
{
    public class ClienteTest
    {
        [Fact]
        public void ValidarInstancia()
        {
            var lNome = "Carlos Eduardo Guimarães de Souza";
            var lDocumento = "475.400.188-52";
            var lCliente = new Cliente(lNome, lDocumento);

            Assert.NotNull(lCliente);
        }

        [Fact]
        public void ValidarTipoCliente_PessoaFisica()
        {
            var lNome = "Carlos Eduardo Guimarães de Souza";
            var lDocumento = "47540018852";
            var lCliente = new Cliente(lNome, lDocumento);

            Assert.True(lCliente.TipoCliente.Equals(ETipoCliente.PessoaFisica));
        }

        [Fact]
        public void ValidarTipoCliente_PessoaJuridica()
        {
            var lNome = "SIZE SECURITIZADORA S.A.";
            var lDocumento = "18695067000153";
            var lCliente = new Cliente(lNome, lDocumento);

            Assert.True(lCliente.TipoCliente.Equals(ETipoCliente.PessoaJurifica));
        }
    }
}
