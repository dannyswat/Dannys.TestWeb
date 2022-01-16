using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public interface IUnitOfWork
	{
		Task SaveChanges();
		Task BeginTransaction();
		Task CommitTransaction();
		Task RollbackTransaction();
		string GetIdentity();
	}
}
