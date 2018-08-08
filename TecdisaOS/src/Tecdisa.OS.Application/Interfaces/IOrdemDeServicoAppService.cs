using System;
using System.Collections.Generic;
using Tecdisa.OS.Application.ViewModel;

namespace Tecdisa.OS.Application.Interfaces
{
    public interface IOrdemDeServicoAppService : IDisposable, IGenericAppService<OrdemDeServicoViewModel>
    {
        IEnumerable<OrdemDeServicoViewModel> ObterPorPeriodo(DateTime inicial, DateTime final);
        
        IEnumerable<OrdemDeServicoViewModel> ObterPorTecnico(string idTecnico);

        IEnumerable<OrdemDeServicoViewModel> ObterPorProgramador(string idProgramador);

        IEnumerable<OrdemDeServicoViewModel> ObterPorCliente(Guid idClient);

        PagedViewModel<OrdemDeServicoViewModel> ObterTodosPaginado(int s, int t);
        
        OrdemDeServicoViewModel Adicionar(OrdemDeServicoViewModel os, string userId);

        void Remover(int id);
    }
}
