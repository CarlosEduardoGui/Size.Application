using Size.Core.Entidade;
using Size.Core.Interface;

namespace Size.Data.Repositorio
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SizeDbContext context) : base(context) { }
    }
}
