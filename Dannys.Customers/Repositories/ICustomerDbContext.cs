using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dannys.Common;
using Microsoft.EntityFrameworkCore;

namespace Dannys.Customers
{
	public interface ICustomerDbContext : IDbContext
	{
		DbSet<Customer> Customers { get; set; }
	}
}
