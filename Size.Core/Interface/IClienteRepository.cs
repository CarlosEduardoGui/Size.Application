using Size.Core.Entidade;

namespace Size.Core.Interface
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        int BuscarUltimaConta();
    }
}
