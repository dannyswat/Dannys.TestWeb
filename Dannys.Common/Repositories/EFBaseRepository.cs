using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
    public abstract class EFBaseRepository<TDbContext> where TDbContext : class, IDbContext
    {
        protected TDbContext GetDbContext(IUnitOfWork unitOfWork)
        {
            if (unitOfWork is IUnitOfWorkEF)
                return GetDbContext(unitOfWork as IUnitOfWorkEF);
            else
                throw new NotSupportedException($"The unit of work must implement {nameof(IUnitOfWorkEF)}");
        }

        protected TDbContext GetDbContext(IUnitOfWorkEF unitOfWork)
        {
            return unitOfWork.GetDbContext<TDbContext>();
        }

        protected int Save(IDbContext dbContext, SaveOption saveOption)
        {
            if (saveOption == SaveOption.ManualSave)
                return 0;

            try
            {
                return dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new ApplicationException("The update is failed due to concurrency. Please try again.", e);
            }
            catch (DbUpdateException e)
            {
                throw;
            }
        }
    }
}
