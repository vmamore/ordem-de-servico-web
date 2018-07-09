using System;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Interfaces
{
    public interface IWriteRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Adicionar(TEntity entidade);

        TEntity Atualizar(TEntity atualizar);

        void Remover(Guid id);

        int SaveChanges();
    }
}
