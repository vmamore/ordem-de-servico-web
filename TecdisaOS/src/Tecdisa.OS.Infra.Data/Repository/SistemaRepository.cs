using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecdisa.OS.Domain.Interfaces;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Infra.Data.Context;

namespace Tecdisa.OS.Infra.Data.Repository
{
    public class SistemaRepository : ISistemaRepository
    {
        private readonly TecdisaContext Db;
        private readonly DbSet<Sistema> DbSet;

        public SistemaRepository(TecdisaContext Db)
        {
            this.Db = Db;
            DbSet = Db.Set<Sistema>();
        }

        public Sistema ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<Sistema> ObterPorNome(string nome)
        {
            return DbSet.Where(c => c.Nome.Contains(nome));
        }

        public IEnumerable<Sistema> ObterTodos()
        {
            return DbSet.ToList();
        }

        public Sistema Adicionar(Sistema sistema)
        {
            var sisReturn = DbSet.Add(sistema);
            return sisReturn;
        }

        public Sistema Atualizar(Sistema sistema)
        {
            var entry = Db.Entry(sistema);
            DbSet.Attach(sistema);
            entry.State = EntityState.Modified;
            return sistema;
        }

        public void Remover(int id)
        {
            var sistema = DbSet.Find(id);
            sistema.Excluir();
            Atualizar(sistema);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose(); ;
        }
    }
}
