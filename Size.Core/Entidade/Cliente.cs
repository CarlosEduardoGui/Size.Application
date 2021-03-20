using Size.Core.Enums;
using System;

namespace Size.Core.Entidade
{
    public class Cliente
    {
        public Cliente() { }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public Documento Documento { get; set; }

        public ETipoCliente TipoCliente { get; set; }

        public Conta Conta { get; set; }

    }
}