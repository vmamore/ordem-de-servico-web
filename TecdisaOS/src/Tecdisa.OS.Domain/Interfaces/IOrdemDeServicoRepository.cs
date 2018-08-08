using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Tecdisa.OS.Domain.DTO;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Interfaces
{
    public interface IOrdemDeServicoRepository : IDisposable
    {
        IEnumerable<OrdemDeServico> ObterTodos();

        IEnumerable<OrdemDeServico> ObterTodosPorCliente(Guid id);

        IEnumerable<OrdemDeServico> ObterTodosPorSistema(string sistema);

        IEnumerable<OrdemDeServico> ObterTodosPorModulo(string modulo);

        IEnumerable<OrdemDeServico> ObterTodosPorTecnico(string id);

        IEnumerable<OrdemDeServico> ObterPorPeriodo(DateTime inicial, DateTime final);

        IEnumerable<OrdemDeServico> ObterPorProgramador(string id);
        
        IEnumerable<OrdemDeServico> Buscar(Expression<Func<OrdemDeServico, bool>> predicate);

        Paged<OrdemDeServico> ObterTodosPaginado(int s, int t);

        OrdemDeServico ObterPorId(int id);

        OrdemDeServico Adicionar(OrdemDeServico entidade);

        OrdemDeServico Atualizar(OrdemDeServico atualizar);

        void Remover(int id);

        int SaveChanges();
    }
}
