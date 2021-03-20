using Size.Core.Entidade;
using Size.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Size.Data.Repositorio
{
    public class HistoricoTransacaoRepository : Repository<HistoricoTransacao>, IHistoricoTransacaoRepository
    {
        public HistoricoTransacaoRepository(SizeDbContext context) : base(context) { }
    }
}
