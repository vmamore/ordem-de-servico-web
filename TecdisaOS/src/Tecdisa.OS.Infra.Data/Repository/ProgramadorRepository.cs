using Dapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tecdisa.OS.Domain.DTO;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.Context;

namespace Tecdisa.OS.Infra.Data.Repository
{
    public class ProgramadorRepository : IProgramadorRepository
    {
        private readonly TecdisaContext Db;
        private readonly DbSet<Programador> DbSet;

        public ProgramadorRepository(TecdisaContext db)
        {
            Db = db;
            DbSet = Db.Set<Programador>();
        }

        public Paged<Programador> ObterTodosPaginado(int s, int t)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Programadores " +
                       "ORDER BY [ID] " +
                       $"OFFSET {s * (t - 1)} " +
                       $"FETCH NEXT {s} ROWS ONLY;" +
                       " " +
                       "SELECT COUNT(Id) FROM Programadores; ";

            var multi = cn.QueryMultiple(sql);
            var programadores = multi.Read<Programador>();
            var count = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<Programador>
            {
                Lista = programadores,
                Count = count
            };

            return pagedList;
        }

        public IEnumerable<Programador> ObterProgramadoresDto()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT Id,Nome,Email FROM Programadores";

            var result = cn.Query<Programador>(sql);

            return result;
        }

        public IEnumerable<Programador> ObterPorNome(string nome)
        {
            return DbSet.Where(p => p.Nome.Contains(nome));
        }

        public IEnumerable<Programador> ObterTodos()
        {
            return DbSet.ToList();
        }

        public Programador ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public Programador Adicionar(Programador programador)
        {
            return DbSet.Add(programador);
        }

        public Programador Atualizar(Programador programador)
        {
            var entry = Db.Entry(programador);
            DbSet.Attach(programador);
            entry.State = EntityState.Modified;
            return programador;
        }

        public void Remover(int id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Programadores " +
                       "WHERE id = @id";

            var programador = cn.Query<Programador>(sql, new { id }).FirstOrDefault();

            programador.Excluir();

            Atualizar(programador);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
