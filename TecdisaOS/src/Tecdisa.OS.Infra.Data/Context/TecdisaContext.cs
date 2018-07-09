using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tecdisa.OS.Infra.Data.Configuration;
using Tecdisa.OS.Infra.Data.EntityConfiguration;

namespace Tecdisa.OS.Infra.Data.Context
{
    public class TecdisaContext : DbContext
    {
        public TecdisaContext()
        {

        }

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
