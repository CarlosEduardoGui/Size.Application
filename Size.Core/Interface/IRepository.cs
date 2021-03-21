using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Size.Core.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);

        TEntity ObterPorId(Guid id);

        Task<List<TEntity>> ObterTodos();

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        int SaveChanges();

    }
}
