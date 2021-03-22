using Size.Core.Entidade;

namespace Size.Core.Interface
{
    public interface IContaRepository : IRepository<Conta>
    {
        int CapturarUltimaConta();
    }
}
