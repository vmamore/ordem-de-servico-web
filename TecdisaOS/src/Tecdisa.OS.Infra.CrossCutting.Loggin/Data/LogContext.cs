using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecdisa.OS.Infra.CrossCutting.Loggin.Model;

namespace Tecdisa.OS.Infra.CrossCutting.Loggin.Data
{
    public class LogContext : DbContext
    {
        public LogContext() : base("DefaultConnection")
        {
        }

        public DbSet<Auditoria> LogAuditoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations
                .Add(new AuditoriaConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
