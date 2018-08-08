using System.Data.Entity.ModelConfiguration;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Infra.Data.Configuration
{
    public class ProgramadorConfig : EntityTypeConfiguration<Programador>
    {
        public ProgramadorConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.DataCadastro)
                .IsRequired();

            Property(p => p.Email)
                .HasMaxLength(250)
                .IsRequired();

            Property(p => p.Ativo)
                .IsRequired();

            Property(p => p.Excluido)
                .IsRequired();

            ToTable("Programadores");
        }
    }
}
