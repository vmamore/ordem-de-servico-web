using System.Collections.Generic;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Interfaces
{
    public interface IClienteRepository: IRepository<Cliente>, IWriteRepository<Cliente>
    {
        IEnumerable<Cliente> ObterPorNome(string nome);

        IEnumerable<Cliente> ObterPorFantasia(string fantasia);

        IEnumerable<Cliente> ObterPorAtividade(string atividade);

        IEnumerable<Cliente> ObterPorTabela(string tabela);

        IEnumerable<Cliente> ObterPorUF(string uf);

        IEnumerable<Cliente> ObterPorCidade(string uf, string cidade);

        Cliente ObterPorCnpj(string cnpj);

        Cliente ObterPorIE(string inscricaoEstadual); 
    }
}
