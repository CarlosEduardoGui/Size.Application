using Size.Data.DTO;
using System;
using System.Collections.Generic;

namespace Size.Data.DTO
{
    public class Conta
    {
        public Guid ID { get; set; }
        public List<HistoricoTransacao> HistoricosTransacoes { get; set; }
    }
}
