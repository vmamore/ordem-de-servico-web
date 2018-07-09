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

            Property(c => c.Atividade)
                .HasMaxLength(4)
                .IsRequired();

            Property(c => c.Atividade)
                .HasMaxLength(2)
                .IsRequired();

            Property(c => c.UsuarioComercial.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.UsuarioComercial.Email)
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.UsuarioExpedicao.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.UsuarioExpedicao.Email)
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.UsuarioFaturista.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.UsuarioFaturista.Email)
                .HasMaxLength(200)
                .IsRequired();
            
            Property(c => c.UsuarioTI.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.UsuarioTI.Email)
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.UsuarioFinanceiro.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.UsuarioFinanceiro.Email)
                .HasMaxLength(200)
                .IsRequired();

            HasRequired(c => c.Endereco)
                .WithMany(e => e.Clientes)
                .HasForeignKey(c => c.EnderecoId);

            ToTable("Clientes");
        }
    }
}
