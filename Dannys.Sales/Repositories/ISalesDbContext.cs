using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dannys.Common;
using Microsoft.EntityFrameworkCore;

namespace Dannys.Sales
{
    public interface ISalesDbContext : ICommonDbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<SalesPerson> SalesPersons { get; set; }

        public DbSet<CustomerPriceGroup> CustomerPriceGroups { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }

        public DbSet<SalesOrderStatus> SalesOrderStatuses { get; set; }
    }
}
