using Dannys.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
    public class CommonService
    {
        public const string CreateAction = "Create";
        public const string UpdateAction = "Update";
        public const string DeleteAction = "Delete";
        public const string ApproveAction = "Approve";
        public const string VoidAction = "Void";
    }
    public class CommonService<TEntity> where TEntity : class, IRootEntity
    {
        protected readonly IRootRepository<TEntity> entityRepository;
        public CommonService(IRootRepository<TEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public virtual Task Validate(ServiceResult result, TEntity entity, TEntity oldEntity = null)
        {
            return Task.CompletedTask;
        }

        protected virtual void CopyUpdateValue(TEntity dest, TEntity source)
        {
            new EntityUpdater().CopyValue(dest, source);
        }

        protected virtual Task Created(IUnitOfWork unitOfWork, TEntity entity)
        {
            return Task.CompletedTask;
        }

        protected virtual Task Updated(IUnitOfWork unitOfWork, TEntity entity)
        {
            return Task.CompletedTask;
        }

        protected virtual Task Deleted(IUnitOfWork unitOfWork, TEntity entity)
        {
            return Task.CompletedTask;
        }

        protected virtual Task Creating(IUnitOfWork unitOfWork, TEntity entity)
        {
            return Task.CompletedTask;
        }

        protected virtual Task Updating(IUnitOfWork unitOfWork, TEntity entity)
        {
            return Task.CompletedTask;
        }

        protected virtual Task Deleting(IUnitOfWork unitOfWork, TEntity entity)
        {
            return Task.CompletedTask;
        }

        public async Task<ServiceResult> Create(IUnitOfWork unitOfWork, TEntity entity, SaveOption saveOption)
        {
            ServiceResult result = new ServiceResult(CommonService.CreateAction);
            await Validate(result, entity);
            if (!result.Success) return result;

            await Creating(unitOfWork, entity);

            entity.Created = new ActionSummary(unitOfWork.GetIdentity());
            entity.LastModified = new ActionSummary(unitOfWork.GetIdentity());

            if ((await entityRepository.Insert(unitOfWork, entity, saveOption)) > 0)
            {
                await Created(unitOfWork, entity);
                result.SetReturn(entity);
            }

            return result;
        }

        public async Task<ServiceResult> Update(IUnitOfWork unitOfWork, TEntity entity, SaveOption saveOption)
        {
            ServiceResult result = new ServiceResult(CommonService.UpdateAction);
            TEntity existing = await entityRepository.Get(unitOfWork, entity.Id);
            await Validate(result, entity, existing);
            if (!result.Success) return result;

            CopyUpdateValue(existing, entity);

            await Updating(unitOfWork, existing);

            existing.LastModified = new ActionSummary(unitOfWork.GetIdentity());

            if ((await entityRepository.Update(unitOfWork, existing, saveOption)) > 0)
            {
                await Updated(unitOfWork, existing);
                result.SetReturn(existing);
            }

            return result;
        }

        public async Task<ServiceResult> Delete(IUnitOfWork unitOfWork, int id, SaveOption saveOption)
        {
            ServiceResult result = new ServiceResult(CommonService.DeleteAction);
            TEntity entity = await entityRepository.Get(unitOfWork, id);
            await Validate(result, entity, entity);
            if (!result.Success) return result;

            await Deleting(unitOfWork, entity);

            if ((await entityRepository.Delete(unitOfWork, id, saveOption)) > 0)
            {
                await Deleted(unitOfWork, entity);
            }

            return result;
        }


    }
}
