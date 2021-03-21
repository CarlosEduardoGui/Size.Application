using Microsoft.EntityFrameworkCore;
using Size.Core.Entidade;
using Size.Core.Interface;
using System.Linq;

namespace Size.Data.Repositorio
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SizeDbContext context) : base(context) { }

        public int BuscarUltimaConta()
        {
            return Db.Cliente
                .Include(x => x.Conta)
                .Select(x => x.Conta.NumeroConta)
                .Max();
        }
    }
}
