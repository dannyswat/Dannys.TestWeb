using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dannys.Common
{
	/// <summary>
	/// Standard DbContext methods that could be used
	/// </summary>
	public interface IDbContext
	{
		int SaveChanges();
		int SaveChanges(bool acceptAllChangesOnSuccess);
		Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default);
		Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, System.Threading.CancellationToken cancellationToken = default);
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		DbSet<TEntity> Set<TEntity>(string name) where TEntity : class;
		void AddAuditTrail<TEntity>(TEntity entity, string identity) where TEntity : class, IEntity;
		Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade Database { get; }
		Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker ChangeTracker { get; }
		Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Entry(object entity);
		Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
	}
}
