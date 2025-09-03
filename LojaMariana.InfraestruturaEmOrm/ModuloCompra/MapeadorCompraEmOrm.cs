
using LojaMariana.Dominio.ModuloCompra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LojaMariana.Infraestrutura.Orm.ModuloCompra
{
    public class MapeadorCompraEmOrm : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(t => t.ValorTotal)
                .IsRequired();

            builder.Property(t => t.Data)
                .IsRequired();

            builder.HasOne(t => t.Cliente)
            .WithMany();

            builder.HasMany(c => c.Produtos)
              .WithOne();
        }
    }
}