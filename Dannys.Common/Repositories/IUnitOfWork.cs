using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public interface IUnitOfWork
	{
		Task<int> SaveChanges();
		Task BeginTransaction();
		Task CommitTransaction();
		Task RollbackTransaction();
		string GetIdentity();
		Task AddAuditTrail<TEntity>(TEntity entity, string action, SaveOption saveOption) where TEntity : class, IEntity;
	}
}
