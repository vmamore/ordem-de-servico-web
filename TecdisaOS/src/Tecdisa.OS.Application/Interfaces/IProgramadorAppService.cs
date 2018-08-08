using System;
using System.Collections.Generic;
using Tecdisa.OS.Application.ViewModel;
using Tecdisa.OS.Infra.Data;

namespace Tecdisa.OS.Application.Interfaces
{
    public interface IProgramadorAppService : IDisposable, IGenericAppService<ProgramadorViewModel>
    {
        IEnumerable<ProgramadorViewModel> ObterPorNome(string nome);

        IEnumerable<ProgramadorViewModel> ObterProgramadoresDto();
            
        PagedViewModel<ProgramadorViewModel> ObterTodosPaginado(int s, int t);
    }
}
