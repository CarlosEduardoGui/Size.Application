﻿using ProjetoSize.Core;
using Size.Core.Entidade;
using Size.Core.Enums;
using Xunit;

namespace Size.Core.Tests
{
    public class ContaTest
    {
        [Fact]
        public void ValidarInstancia()
        {
            var lCliente = Cliente.NovoCliente("Carlos Eduardo", "47540018852");
            var lConta = Conta.NovaConta(lCliente);

            Assert.NotNull(lConta);
        }
    }
}