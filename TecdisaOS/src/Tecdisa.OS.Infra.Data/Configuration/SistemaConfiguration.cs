using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Infra.Data.Configuration
{
    public class SistemaConfiguration : EntityTypeConfiguration<Sistema>
    {
        public SistemaConfiguration()
        {
            HasKey(s => s.Id);

            Property(s => s.Nome)
                .HasMaxLength(30)
                .IsRequired();

            Property(s => s.Ativo)
                .IsRequired();

            Property(s => s.Excluido)
                .IsRequired();

            ToTable("Sistemas");
        }
    }
}
