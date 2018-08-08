using System;
using System.Collections.Generic;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Interfaces
{
    public interface IModuloRepository : IDisposable
    {
        IEnumerable<Modulo> ObterTodos();

        IEnumerable<Modulo> ObterTodosComSistema();

        IEnumerable<Modulo> ObterPorNome(string nome);
        
        IEnumerable<Modulo> ObterPorSistema(int id);

        Modulo ObterPorId(int id);
        
        Modulo Adicionar(Modulo modulo);

        Modulo Atualizar(Modulo modulo);

        void Remover(int id);
    }
}
