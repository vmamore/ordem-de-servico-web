using System;
using System.Collections.Generic;
using Tecdisa.OS.Domain.DTO;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Interfaces
{
    public interface IProgramadorRepository : IDisposable
    {
        IEnumerable<Programador> ObterTodos();

        IEnumerable<Programador> ObterPorNome(string nome);

        IEnumerable<Programador> ObterProgramadoresDto();

        Paged<Programador> ObterTodosPaginado(int s, int t);
        
        Programador ObterPorId(int id);

        Programador Adicionar(Programador programador);

        Programador Atualizar(Programador programador);

        void Remover(int id);
    }
}
