using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Interfaces
{
    public interface ISistemaRepository : IDisposable
    {
        Sistema ObterPorId(int id);

        IEnumerable<Sistema> ObterTodos();

        IEnumerable<Sistema> ObterPorNome(string nome);

        Sistema Adicionar(Sistema sistema);

        Sistema Atualizar(Sistema sistema);

        void Remover(int id);

        int SaveChanges();
    }
}
