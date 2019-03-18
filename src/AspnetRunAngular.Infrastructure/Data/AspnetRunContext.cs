using AspnetRunAngular.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace AspnetRunAngular.Infrastructure.Data
{
    public class AspnetRunContext : DbContext
    {
        public AspnetRunContext(DbContextOptions<AspnetRunContext> options/*, IComponentContext container*/)
            : base(options)
        {
            //_container = container;
        }

        private IDbContextTransaction _currentTransaction;
        //private readonly IComponentContext _container;

        public IDbContextTransaction GetCurrentTransaction => _currentTransaction;

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.CreateSequences(_container);

            modelBuilder.Entity<Order>(OrderItemiseEntityConfigurations.ConfigureOrder);
            modelBuilder.Entity<OrderItem>(OrderItemiseEntityConfigurations.ConfigureOrderItem);
            modelBuilder.Entity<Product>(OrderItemiseEntityConfigurations.ConfigureProduct);
        }

        public async Task BeginTransactionAsync()
        {
            _currentTransaction = _currentTransaction ?? await Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }

    static class OrderItemiseEntityConfigurations
    {
        //internal static void CreateSequences(this ModelBuilder modelBuilder, IComponentContext container)
        //{
        //    var sequenceProvider = container.Resolve<ISequenceProvider>();

        //    sequenceProvider.GetSequences().ToList().ForEach(sequence =>
        //        modelBuilder.HasSequence<int>(sequence.Name).StartsAt(1).IncrementsBy(1)
        //    );
        //}

        internal static void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
        }

        internal static void ConfigureOrderItem(EntityTypeBuilder<OrderItem> builder)
        {
        }

        internal static void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
        }
    }
}
