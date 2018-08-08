using System.Data.Entity.ModelConfiguration;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Infra.Data.EntityConfiguration
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.Fantasia)
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.CNPJ)
                .HasMaxLength(14)
                .IsFixedLength()
                .IsRequired();

            Property(c => c.InscricaoEstadual)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.Telefone)
                .HasMaxLength(14)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.Excluido)
                .IsRequired();

            Property(c => c.Atividade)
                .IsRequired();

            Property(c => c.Tabela)
                .IsRequired();

            Property(c => c.UsuarioComercial.Nome)
                .HasColumnName("UsuarioComercialNome")
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.UsuarioComercial.Email)
                .HasColumnName("UsuarioComercialEmail")
                .HasMaxLength(200)
                .IsRequired();
            
            Property(c => c.UsuarioFinanceiro.Nome)
                .HasColumnName("UsuarioFinanceiroNome")
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.UsuarioFinanceiro.Email)
                .HasColumnName("UsuarioFinanceiroEmail")
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.UsuarioContabil.Nome)
                .HasColumnName("UsuarioContabilNome")
                .HasMaxLength(100);

            Property(c => c.UsuarioContabil.Email)
                .HasColumnName("UsuarioContabilEmail")
                .HasMaxLength(200);

            Property(c => c.UsuarioExpedicao.Nome)
                .HasColumnName("UsuarioExpedicaoNome")
                .HasMaxLength(100);

            Property(c => c.UsuarioFaturamento.Nome)
                .HasColumnName("UsuarioFaturamentoNome")
                .HasMaxLength(100);

            Property(c => c.UsuarioTI.Nome)
                .HasColumnName("UsuarioTINome")
                .HasMaxLength(100);
            
            ToTable("Clientes");
        }
    }
}
