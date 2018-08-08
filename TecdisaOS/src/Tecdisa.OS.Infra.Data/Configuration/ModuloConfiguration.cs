using System.Data.Entity.ModelConfiguration;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Infra.Data.Configuration
{
    public class ModuloConfiguration : EntityTypeConfiguration<Modulo>
    {
        public ModuloConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Nome)
                .HasMaxLength(60)
                .IsRequired();

            Property(m => m.Ativo)
                .IsRequired();

            HasRequired(m => m.Sistema)
                .WithMany(s => s.Modulos)
                .HasForeignKey(m => m.SistemaId);

            ToTable("Modulos");
        }
    }
}
