using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public interface IRootRepository<TEntity> : IRepository<TEntity> where TEntity : IRootEntity
	{
		TEntity Get(IUnitOfWork unitOfWork, int id);
	}
}
