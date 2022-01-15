using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public interface ILineRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
	{
		IEnumerable<TEntity> GetByHeaderId(IUnitOfWork unitOfWork, int id);
	}
}
