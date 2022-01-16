using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
    public class EFCommonRepository<TEntity, TDbContext> : EFBaseRepository<TDbContext>, IRepository<TEntity>
        where TEntity : class, IEntity
        where TDbContext : class, IDbContext
    {
        public virtual int Delete(IUnitOfWork unitOfWork, int id, SaveOption saveOption = SaveOption.Default)
        {
            var dbContext = GetDbContext(unitOfWork);
            var dbSet = dbContext.Set<TEntity>();
            var entity = dbSet.Find(id);
            if (entity == null)
                throw new EntityNotFoundException<TEntity>(id);
            dbSet.Remove(entity);
            return Save(dbContext, saveOption);
        }

        public virtual int Insert(IUnitOfWork unitOfWork, TEntity entity, SaveOption saveOption = SaveOption.Default)
        {
            var dbContext = GetDbContext(unitOfWork);
            dbContext.Set<TEntity>().Add(entity);
            return Save(dbContext, saveOption);
        }

        public virtual int Update(IUnitOfWork unitOfWork, TEntity entity, SaveOption saveOption = SaveOption.Default)
        {
            var dbContext = GetDbContext(unitOfWork);
            dbContext.Set<TEntity>().Update(entity);
            return Save(dbContext, saveOption);
        }
    }
}
