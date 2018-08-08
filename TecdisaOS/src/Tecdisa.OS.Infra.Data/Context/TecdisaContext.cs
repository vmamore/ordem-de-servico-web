using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Tecdisa.OS.Domain.Models;
using Tecdisa.OS.Domain.ValueObjects;
using Tecdisa.OS.Infra.Data.Configuration;
using Tecdisa.OS.Infra.Data.EntityConfiguration;

namespace Tecdisa.OS.Infra.Data.Context
{
    public class TecdisaContext : DbContext
    {
        public TecdisaContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Sistema> Sistemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Programador> Programadores { get; set; }
        public DbSet<OrdemDeServico> OrdemDeServicos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new OrdemDeServicoConfig());
            modelBuilder.Configurations.Add(new ProgramadorConfig());
            modelBuilder.Configurations.Add(new SistemaConfiguration());
            modelBuilder.Configurations.Add(new ModuloConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
