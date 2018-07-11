using System.Data.Entity.ModelConfiguration;
using Tecdisa.OS.Domain.Models;

namespace Tecdisa.OS.Infra.Data.Configuration
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        //TODO verificar propriedades e relacionamento
        public EnderecoConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .HasMaxLength(200)
                .IsRequired();

            Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsRequired();

            Property(e => e.Numero)
                .HasMaxLength(10)
                .IsRequired();

            Property(e => e.Cidade)
                .HasMaxLength(150)
                .IsRequired();

            Property(e => e.UF)
                .HasMaxLength(2)
                .IsRequired();

            Property(e => e.CEP)
                .HasMaxLength(8)
                .IsFixedLength()
                .IsRequired();

            ToTable("Enderecos");
        }
    }
}
