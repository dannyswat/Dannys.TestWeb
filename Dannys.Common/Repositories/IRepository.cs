using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
	public interface IRepository<TEntity> where TEntity : IEntity
	{
		int Insert(IUnitOfWork unitOfWork, TEntity entity, SaveOption saveOption = SaveOption.Default);
		int Update(IUnitOfWork unitOfWork, TEntity entity, SaveOption saveOption = SaveOption.Default);
		int Delete(IUnitOfWork unitOfWork, int id, SaveOption saveOption = SaveOption.Default);
	}
}
