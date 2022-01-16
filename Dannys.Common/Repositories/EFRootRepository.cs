using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
    public class EFRootRepository<TEntity, TDbContext> : EFCommonRepository<TEntity, TDbContext>, IRootRepository<TEntity>
        where TEntity : class, IRootEntity
        where TDbContext : class, IDbContext
    {
        public virtual TEntity Get(IUnitOfWork unitOfWork, int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var dbContext = GetDbContext(unitOfWork);
            var dbSet = dbContext.Set<TEntity>();
            var qry = dbSet.Where(r => r.Id == id);
            foreach (var prop in includeProperties)
                qry = qry.Include(prop);
            var entity = qry.FirstOrDefault();
            if (entity == null)
                throw new EntityNotFoundException<TEntity>(id);
            return entity;
        }
    }
}
