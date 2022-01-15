using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public interface IUnitOfWorkEF<TDbContext> : IUnitOfWork
		where TDbContext : IDbContext
	{
		TDbContext GetDbContext();
	}
}
