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
        DbSet<Customer> Customers { get; set; }

        DbSet<SalesPerson> SalesPersons { get; set; }

        DbSet<CustomerPriceGroup> CustomerPriceGroups { get; set; }

        DbSet<SalesOrder> SalesOrders { get; set; }

        DbSet<SalesOrderStatus> SalesOrderStatuses { get; set; }
    }
}
