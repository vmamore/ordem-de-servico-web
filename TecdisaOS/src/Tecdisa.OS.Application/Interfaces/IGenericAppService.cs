using System;
using System.Collections.Generic;

namespace Tecdisa.OS.Application.Interfaces
{
    public interface IGenericAppService<EntityViewModel> : IDisposable where EntityViewModel : class
    {
        IEnumerable<EntityViewModel> ObterTodos();

        EntityViewModel Adicionar(EntityViewModel entity);

        EntityViewModel Atualizar(EntityViewModel entity);

        EntityViewModel ObterPorId(int id);
        
        void Remover(int id);
    }
}
