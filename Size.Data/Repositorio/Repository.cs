using Microsoft.EntityFrameworkCore;
using Size.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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


        public virtual List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            SaveChanges();
        }

        public virtual void Atualizar(TEntity obj)
        {
            //if (Db.Entry(obj).State != EntityState.Modified) obj = DbSet.Find(obj);
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
