using System.Collections.Generic;
using System.Linq;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public IEnumerable<Cliente> ObterPorAtividade(string atividade)
        {
            return Buscar(c => c.Atividade == atividade);
        }

        public IEnumerable<Cliente> ObterPorUF(string uf)
        {
            return Buscar(c => c.Endereco.UF == uf);
        }

        public IEnumerable<Cliente> ObterPorCidade(string uf, string cidade)
        {
            return Buscar(c => c.Endereco.Cidade == cidade && c.Endereco.UF == uf);
        }

        public IEnumerable<Cliente> ObterPorFantasia(string fantasia)
        {
            return Buscar(c => c.Fantasia == fantasia);
        }

        public IEnumerable<Cliente> ObterPorNome(string nome)
        {
            return Buscar(c => c.Nome == nome);
        }

        public IEnumerable<Cliente> ObterPorTabela(string tabela)
        {
            // TODO check
            return Buscar(c => c.Tabela.ToString() == tabela);
        }

        public Cliente ObterPorIE(string inscricaoEstadual)
        {
            return Buscar(c => c.InscricaoEstadual == inscricaoEstadual).FirstOrDefault();
        }

        public Cliente ObterPorCnpj(string cnpj)
        {
            return Buscar(c => c.CNPJ == cnpj).FirstOrDefault();
        }

    }
}
