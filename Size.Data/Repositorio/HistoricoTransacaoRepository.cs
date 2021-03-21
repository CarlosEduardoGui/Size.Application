using Size.Core.Entidade;
using Size.Core.Interface;

namespace Size.Data.Repositorio
{
    public class HistoricoTransacaoRepository : Repository<HistoricoTransacao>, IHistoricoTransacaoRepository
    {
        public HistoricoTransacaoRepository(SizeDbContext context) : base(context) { }
    }
}
