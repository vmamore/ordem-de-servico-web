using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.Context;

namespace Tecdisa.OS.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IWriteRepository<TEntity> where TEntity : Entity, new()
    {
        protected TecdisaContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(TecdisaContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public TEntity Adicionar(TEntity obj)
        {
            var returnObj = DbSet.Add(obj);
            return returnObj;
        }

        public TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            return obj;
        }

        public virtual void Remover(Guid id)
        {
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
