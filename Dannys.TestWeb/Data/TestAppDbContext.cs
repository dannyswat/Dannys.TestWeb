using Dannys.Common;
using Dannys.Sales;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dannys.TestWeb.Data
{
    public class TestAppDbContext : DbContext, ISalesDbContext
    {
        public TestAppDbContext() : base() { }

        public TestAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<CustomerPriceGroup> CustomerPriceGroups { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderStatus> SalesOrderStatuses { get; set; }

        public void AddAuditTrail<TEntity>(TEntity entity, string identity) where TEntity : class, IEntity
        {
            Audit<TEntity> audit = new Audit<TEntity>();
            audit.RecordId = entity.Id;
            audit.Done = new ActionSummary(identity);
            audit.Content = entity;
            audit.RecordKey = string.Empty;
            Set<Audit<TEntity>>().Add(audit);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
