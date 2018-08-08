using System;
using System.Collections.Generic;
using Tecdisa.OS.Domain.DTO;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Domain.Interfaces
{
    public interface IClienteRepository: IRepository<Cliente>, IWriteRepository<Cliente>
    {
        IEnumerable<Cliente> ObterPorNome(string nome);
        
        IEnumerable<Cliente> ObterPorFantasia(string fantasia);

        IEnumerable<Cliente> ObterPorAtividade(int atividade);

        IEnumerable<Cliente> ObterPorTabela(string tabela);

        IEnumerable<Cliente> ObterPorUF(string uf);

        IEnumerable<Cliente> ObterPorCidade(string uf, string cidade);

        IEnumerable<Cliente> ObterAtivos();

        Paged<Cliente> ObterTodosPaginado(string name, int s, int t);
        
        Cliente ObterPorCnpj(string cnpj);

        Cliente ObterPorIE(string inscricaoEstadual);

        Cliente ObterPorIdSemEndereco(Guid id);

        string ObterUsuario(Guid idCliente);
    }
}
