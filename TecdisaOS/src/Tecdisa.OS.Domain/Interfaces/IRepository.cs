using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IEnumerable<TEntity> ObterTodos();
        
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        TEntity ObterPorId(Guid id);
    }
}
