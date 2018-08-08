using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tecdisa.OS.Domain.DTO;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.Context;

namespace Tecdisa.OS.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TecdisaContext db) : base(db)
        {

        }
        //public override Cliente ObterPorId(Guid id)
        //{
        //    var sql = @"SELECT * FROM Clientes c " +
        //               "LEFT JOIN Enderecos e " +
        //               "ON c.Id = e.ClienteId " +
        //               "WHERE c.Id = @uid;";

        //    var cliente = Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql, (c, e) =>
        //    {
        //        c.AdicionarEndereco(e);
        //        return c;
        //    }, new { uid = id }).FirstOrDefault();

        //    return cliente;
        //}
        
        public IEnumerable<Cliente> ObterAtivos()
        {
            var sql = @"SELECT * FROM Clientes c " +
                       "LEFT JOIN Enderecos e " +
                       "ON c.Id = e.ClienteId " +
                       "WHERE c.Ativo = 1 AND c.Excluido = 0;";

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql, (c, e) =>
            {
                c.AdicionarEndereco(e);
                return c;
            });
        }

        public IEnumerable<Cliente> ObterPorAtividade(int atividade)
        {
            return Buscar(c => c.Atividade == atividade);
        }

        public IEnumerable<Cliente> ObterPorUF(string uf)
        {
            return Buscar(c => c.Enderecos.FirstOrDefault().UF == uf);
        }

        public IEnumerable<Cliente> ObterPorCidade(string uf, string cidade)
        {
            return Buscar(c => c.Enderecos.FirstOrDefault().Cidade == cidade && c.Enderecos.FirstOrDefault().UF == uf);
        }

        public IEnumerable<Cliente> ObterPorFantasia(string fantasia)
        {
            return Buscar(c => c.Fantasia == fantasia);
        }

        public IEnumerable<Cliente> ObterPorNome(string nome)
        {
            return Buscar(c => c.Nome.Contains(nome));
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

        public override Cliente ObterPorId(Guid id)
        {
            //var connection = Db.Database.Connection;

            //var sql = @"SELECT * FROM Clientes c" +
            //           "LEFT JOIN Enderecos e " +
            //           "ON c.Id = e.ClienteId " +
            //           "WHERE c.Id = @uid ";

            //return connection.Query<Cliente, Endereco, Cliente>(sql, (c, e) =>
            //{
            //    c.Enderecos.Add(e);
            //    return c;
            //}, new { uid = id }).FirstOrDefault();

            return DbSet.Include(c => c.Enderecos).FirstOrDefault(c => c.Id == id);
        }

        public Cliente ObterPorIdSemEndereco(Guid id)
        {
            return DbSet.Find(id);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Excluir();
            Atualizar(cliente);
        }

        public Paged<Cliente> ObterTodosPaginado(string nome, int s, int t)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes " +
                       "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') " +
                       "ORDER BY [NOME] " +
                       $"OFFSET {s * (t - 1)} ROWS " +
                       $"FETCH NEXT {s} ROWS ONLY " +
                       " " +
                       "SELECT COUNT(Id) FROM Clientes " +
                       "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') ";

            var multi = cn.QueryMultiple(sql, new { Nome = nome });
            var clientes = multi.Read<Cliente>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<Cliente>
            {
                Lista = clientes,
                Count = total
            };

            return pagedList;
        }

        public string ObterUsuario(Guid idCliente)
        {
            var sql = @"SELECT UsuarioFaturamentoNome FROM Clientes c " +
                       "WHERE c.Id = @uid";

            var multi = Db.Database.Connection.QueryMultiple(sql, new { uid = idCliente });
            var result = multi.Read<string>().FirstOrDefault();

            return result;
        }
    }
}
