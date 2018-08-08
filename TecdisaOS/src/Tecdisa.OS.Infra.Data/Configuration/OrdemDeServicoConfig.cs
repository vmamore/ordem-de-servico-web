using System.Data.Entity.ModelConfiguration;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Infra.Data.Configuration
{
    public class OrdemDeServicoConfig : EntityTypeConfiguration<OrdemDeServico>
    {
        public OrdemDeServicoConfig()
        {
            HasKey(o => o.Id);

            Property(o => o.ClienteId)
                .IsRequired();

            Property(o => o.ClienteNome)
                .HasMaxLength(200)
                .IsRequired();

            Property(o => o.NomeDoFaturista)
                .HasMaxLength(100)
                .IsRequired();

            Property(o => o.HoraCadastro)
                .IsRequired();

            Property(o => o.DataCadastro)
                .IsRequired();

            Property(o => o.HoraDeFechamento)
                .IsOptional();

            Property(o => o.DataDeFechamento)
                .IsOptional();

            Property(o => o.NecessitaDeAjuste)
                .IsRequired();

            Property(o => o.Excluido)
                .IsRequired();

            Property(o => o.TecnicoId)
                .HasColumnName("TecnicoId")
                .IsRequired();

            Property(o => o.Programador)
                .HasColumnName("Programador")
                .IsOptional();

            Property(o => o.Problema)
                .HasMaxLength(500)
                .IsRequired();

            Property(o => o.Solucao)
                .HasMaxLength(500);

            Property(o => o.Observacao)
                .HasMaxLength(500);

            ToTable("OrdemDeServicos");
        }
    }
}
