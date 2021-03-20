using Size.Data.DTO;
using Size.Data.Enums;
using System;

namespace Size.Data.DTO
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public Documento Documento { get; set; }

        public ETipoCliente TipoCliente { get; set; }

        public Conta Conta { get; set; }
    }
}
