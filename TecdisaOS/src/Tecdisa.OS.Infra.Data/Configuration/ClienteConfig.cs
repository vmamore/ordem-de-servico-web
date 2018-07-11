using System.Data.Entity.ModelConfiguration;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Infra.Data.EntityConfiguration
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        // TODO verificar as propriedades e relacionamento
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

            Property(c => c.Atividade)
                .IsRequired();

            Property(c => c.Tabela)
                .IsRequired();

            Property(c => c.UsuarioComercial.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.UsuarioComercial.Email)
                .HasMaxLength(200)
                .IsRequired();
            
            Property(c => c.UsuarioFinanceiro.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.UsuarioFinanceiro.Email)
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.UsuarioContabil.Nome)
                .HasMaxLength(100);

            Property(c => c.UsuarioContabil.Email)
                .HasMaxLength(200);

            Property(c => c.UsuarioExpedicao.Nome)
                .HasMaxLength(100);

            Property(c => c.UsuarioFaturista.Nome)
                .HasMaxLength(100);

            Property(c => c.UsuarioTI.Nome)
                .HasMaxLength(100);
            
            ToTable("Clientes");
        }
    }
}
