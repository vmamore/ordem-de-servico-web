using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Tecdisa.OS.Domain.DTO;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.Context;

namespace Tecdisa.OS.Infra.Data.Repository
{
    public class OrdemDeServicoRepository : IOrdemDeServicoRepository
    {
        private readonly TecdisaContext Db;
        private readonly DbSet<OrdemDeServico> DbSet;

        public OrdemDeServicoRepository(TecdisaContext Db)
        {
            this.Db = Db;
            DbSet = Db.Set<OrdemDeServico>();
        }

        public OrdemDeServico Adicionar(OrdemDeServico os)
        {
            var objReturn = DbSet.Add(os);
            return objReturn;
        }

        public OrdemDeServico Atualizar(OrdemDeServico os)
        {
            var entry = Db.Entry(os);
            DbSet.Attach(os);
            entry.State = EntityState.Modified;
            return os;
        }

        public IEnumerable<OrdemDeServico> Buscar(Expression<Func<OrdemDeServico, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IEnumerable<OrdemDeServico> ObterPorPeriodo(DateTime inicial, DateTime final)
        {
            return Buscar(o => o.DataCadastro <= inicial && o.DataCadastro >= final);
        }

        public IEnumerable<OrdemDeServico> ObterPorProgramador(string nome)
        {
            return Buscar(o => o.Programador == nome);
        }

        public OrdemDeServico ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<OrdemDeServico> ObterTodos()
        {
            return DbSet.ToList();
        }

        public IEnumerable<OrdemDeServico> ObterTodosPorCliente(Guid id)
        {
            return DbSet.Where(o => o.ClienteId == id);
        }

        public IEnumerable<OrdemDeServico> ObterTodosPorModulo(string modulo)
        {
            return DbSet.Where(o => o.Modulo == modulo);
        }

        public IEnumerable<OrdemDeServico> ObterTodosPorSistema(string sistema)
        {
            return DbSet.Where(o => o.Sistema == sistema); ;
        }

        public IEnumerable<OrdemDeServico> ObterTodosPorTecnico(string id)
        {
            return DbSet.Where(o => o.TecnicoId == id);
        }

        public void Remover(int id)
        {
            var os = ObterPorId(id);
            os.Excluir();
            Atualizar(os);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        
        public void Dispose()
        {
            Db.Dispose();
        }

        public Paged<OrdemDeServico> ObterTodosPaginado(int s, int t)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM OrdemDeServicos " +
                       "ORDER BY DataCadastro, HoraCadastro " +
                       $"OFFSET {s * (t - 1) } ROWS " +
                       $"FETCH NEXT {s} ROWS ONLY;" +
                       " " +
                       "SELECT COUNT(Id) FROM OrdemDeServicos";

            var multi = cn.QueryMultiple(sql);
            var ordemDeServico = multi.Read<OrdemDeServico>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<OrdemDeServico>
            {
                Lista = ordemDeServico,
                Count = total
            };
            
            return pagedList;
        }
    }
}
