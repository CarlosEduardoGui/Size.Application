using Size.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Size.Core.Entidade
{
    public class Cliente
    {

        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public Documento Documento { get; set; }

        [JsonIgnore]
        public ETipoCliente TipoCliente { get; set; }

        public Conta Conta { get; set; }


        public Cliente() { Id = Guid.NewGuid(); }

    }
}