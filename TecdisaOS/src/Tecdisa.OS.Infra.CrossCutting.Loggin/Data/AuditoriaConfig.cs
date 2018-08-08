using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecdisa.OS.Infra.CrossCutting.Loggin.Model;

namespace Tecdisa.OS.Infra.CrossCutting.Loggin.Data
{
    public class AuditoriaConfig : EntityTypeConfiguration<Auditoria>
    {
        public AuditoriaConfig()
        {
            HasKey(a => a.LogId);

            Property(a => a.Sistema)
                .IsRequired()
                .HasMaxLength(150);

            Property(a => a.Acao)
                .IsRequired()
                .HasMaxLength(1000);

            Property(a => a.IP)
                .IsRequired()
                .HasMaxLength(20);

            Property(a => a.UserId)
                .IsRequired()
                .HasMaxLength(150);

            ToTable("LogAuditoria");
        }
    }
}
