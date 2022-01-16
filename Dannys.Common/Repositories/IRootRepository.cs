using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public interface IRootRepository<TEntity> : IRepository<TEntity> where TEntity : IRootEntity
	{
		Task<TEntity> Get(IUnitOfWork unitOfWork, int id, params Expression<Func<TEntity, object>>[] includeProperties);
	}
}
