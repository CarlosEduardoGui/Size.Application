using System;
using System.ComponentModel.DataAnnotations;

namespace Size.Core.Entidade
{
    public class Conta
    {
        [Key]
        public Guid ID { get; set; }
        public int NumeroConta { get; set; }
        public double Valor { get; set; }

        public Conta() { ID = Guid.NewGuid(); }


    }
}
