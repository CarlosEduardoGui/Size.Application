using Size.Core.Entidade;
using Xunit;

namespace Size.Core.Tests
{
    public class ContaTest
    {
        [Fact]
        public void ValidarInstancia()
        {
            var lCliente = new Cliente();
            var lConta = new Conta();

            Assert.NotNull(lConta);
        }
    }
}
