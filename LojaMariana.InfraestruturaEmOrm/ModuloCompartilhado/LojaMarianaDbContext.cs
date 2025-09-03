using LojaMariana.Dominio.Compartilhado;
using LojaMariana.Dominio.ModuloCliente;
using LojaMariana.Dominio.ModuloCompra;
using LojaMariana.Dominio.ModuloProduto;
using LojaMariana.Infraestrutura.Orm.ModuloCliente;
using LojaMariana.Infraestrutura.Orm.ModuloCompra;
using LojaMariana.Infraestrutura.Orm.ModuloProduto;
using Microsoft.EntityFrameworkCore;

namespace LojaMariana.Infraestrutura.Orm.Compartilhado
{
    public class lojaMarianaDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public lojaMarianaDbContext(DbContextOptions<lojaMarianaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(lojaMarianaDbContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.ApplyConfiguration(new MapeadorClienteEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorProdutoEmOrm());
            modelBuilder.ApplyConfiguration(new MapeadorCompraEmOrm());
            base.OnModelCreating(modelBuilder);
        }
        public void Commit()
        {
            SaveChanges();
        }

        public void Rollback()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}