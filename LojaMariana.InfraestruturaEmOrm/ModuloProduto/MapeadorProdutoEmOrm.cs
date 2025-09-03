
using LojaMariana.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaMariana.Infraestrutura.Orm.ModuloProduto
{
    public class MapeadorProdutoEmOrm : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.Property(t => t.Id)
              .IsRequired()
              .ValueGeneratedNever();

            builder.Property(t => t.Nome)
                .IsRequired();

            builder.Property(t => t.Preco)
                .IsRequired();

            builder.Property(t => t.Tamanho)
                .IsRequired();

            builder.Property(t => t.Categoria)
                .IsRequired();

            builder.Property(t => t.QuantidadeEstoque)
                .IsRequired();

            builder.Property(t => t.CodigoLive)
                .IsRequired();
        }
    }
}