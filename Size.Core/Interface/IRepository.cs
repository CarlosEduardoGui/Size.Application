using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Size.Core.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);

        TEntity ObterPorId(Guid id);

        Task<List<TEntity>> ObterTodos();

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        int SaveChanges();

    }
}
