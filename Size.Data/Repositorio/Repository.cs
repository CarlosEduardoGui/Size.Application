using Microsoft.EntityFrameworkCore;
using Size.Core.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Size.Data.Repositorio
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SizeDbContext Db;

        protected readonly DbSet<TEntity> DbSet;

        public Repository(SizeDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }


        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }


        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            SaveChanges();
        }

        public virtual void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
            SaveChanges();
        }


        public virtual void Remover(TEntity obj)
        {
            DbSet.Remove(obj);
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
