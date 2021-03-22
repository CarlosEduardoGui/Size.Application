using Size.Core.Entidade;
using Size.Core.Interface;

namespace Size.Data.Repositorio
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(SizeDbContext context) : base(context) { }

        public int CapturarUltimaConta()
        {
            throw new System.NotImplementedException();
        }
    }
}
