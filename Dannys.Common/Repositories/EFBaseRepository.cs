using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        protected async Task AddAuditTrail<TEntity>(IUnitOfWork unitOfWork, TEntity entity, [CallerMemberName] string action = "")
            where TEntity : class, IEntity
        {
            await unitOfWork.AddAuditTrail(entity, action, SaveOption.ManualSave);
        }

        protected async Task<int> Save(IUnitOfWork unitOfWork, SaveOption saveOption)
        {
            if (saveOption == SaveOption.ManualSave)
                return 0;

            try
            {
                return await unitOfWork.SaveChanges();
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
