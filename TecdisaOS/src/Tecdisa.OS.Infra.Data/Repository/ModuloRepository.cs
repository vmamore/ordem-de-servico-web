using Dapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.Context;

namespace Tecdisa.OS.Infra.Data.Repository
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly TecdisaContext Db;
        private readonly DbSet<Modulo> DbSet;

        public ModuloRepository(TecdisaContext db)
        {
            Db = db;
            DbSet = Db.Set<Modulo>();
        }

        public IEnumerable<Modulo> ObterTodos()
        {
            return DbSet.ToList();
        }

        public IEnumerable<Modulo> ObterPorSistema(int id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT Id, Nome FROM Modulos m " +
                       "WHERE m.SistemaId = @uid";

            return cn.Query<Modulo>(sql, new { uid = id });

            // return DbSet.Where(m => m.SistemaId == id);
        }

        public IEnumerable<Modulo> ObterTodosComSistema()
        {
            return DbSet.Include(m => m.Sistema).OrderBy(m => m.Sistema.Nome).ToList();
        }

        public IEnumerable<Modulo> ObterPorNome(string nome)
        {
            return DbSet.Where(m => m.Nome.Contains(nome));
        }

        public Modulo ObterPorId(int id)
        {
            return DbSet.Include(m => m.Sistema).FirstOrDefault(m => m.Id == id);
        }

        public Modulo Adicionar(Modulo modulo)
        {
            var modReturn = DbSet.Add(modulo);
            return modReturn;
        }

        public Modulo Atualizar(Modulo modulo)
        {
            var entry = Db.Entry(modulo);
            DbSet.Attach(modulo);
            entry.State = EntityState.Modified;
            return modulo;
        }

        public void Remover(int id)
        {
            var modulo = ObterPorId(id);
            modulo.Excluir();
            Atualizar(modulo);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
