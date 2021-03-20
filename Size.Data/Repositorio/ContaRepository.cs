using Size.Core.Entidade;
using Size.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Size.Data.Repositorio
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(SizeDbContext context) : base(context) { }

    }
}
