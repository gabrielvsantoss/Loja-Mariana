
using LojaMariana.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaMariana.Infraestrutura.Orm.ModuloCliente;
    public class MapeadorClienteEmOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(t => t.Id)
               .IsRequired()
               .ValueGeneratedNever();

            builder.Property(t => t.Nome)
                .IsRequired();

            builder.Property(t => t.Telefone)
                .IsRequired();

            builder.Property(t => t.Endereco)
                .IsRequired();

            builder.Property(t => t.Email)
                .IsRequired();
        }
    }
