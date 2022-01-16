using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
    public abstract class EFUnitOfWork<TDbContext> : IUnitOfWorkEF where TDbContext : class, IDbContext
    {
        IDbContextTransaction dbTrn;
        TDbContext context;
        string userName;

        public EFUnitOfWork(TDbContext context, IRequestIdentity requestIdentity)
        {
            this.context = context;
            userName = requestIdentity.GetUserName();
        }

        public async Task BeginTransaction()
        {
            dbTrn = await context.Database.BeginTransactionAsync();
        }

        public Task CommitTransaction()
        {
            if (dbTrn == null)
                throw new InvalidOperationException("A transaction has not started");

            return dbTrn.CommitAsync();
        }

        public T GetDbContext<T>() where T : class, IDbContext
        {
            if (context is T)
                return context as T;
            else
                throw new InvalidOperationException($"The DbContext does not implement {nameof(TDbContext)}");
        }

        public string GetIdentity()
        {
            return userName;
        }

        public Task RollbackTransaction()
        {
            if (dbTrn == null)
                throw new InvalidOperationException("A transaction has not started");

            return dbTrn.RollbackAsync();
        }

        public Task SaveChanges()
        {
            return context.SaveChangesAsync();
        }
    }
}
