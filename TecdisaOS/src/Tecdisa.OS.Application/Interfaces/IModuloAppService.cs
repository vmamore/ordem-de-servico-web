using System.Collections.Generic;
using Tecdisa.OS.Application.ViewModel;

namespace Tecdisa.OS.Application.Interfaces
{
    public interface IModuloAppService : IGenericAppService<ModuloViewModel>
    {
        IEnumerable<ModuloViewModel> ObterTodosComSistema();

        IEnumerable<ModuloViewModel> ObterModulos(int sistemaId);
    }
}
