using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common.Users
{
    public class UserService : CommonService<User>
    {
        const string ChangePasswordAction = "ChangePassword";
        readonly IUserRepository userRepository;

        public UserService(IUserRepository repository) : base(repository)
        {
            userRepository = repository;
        }

        public async override Task Validate(ServiceResult result, User entity, User oldEntity = null)
        {
            switch (result.Action)
            {
                case CommonService.CreateAction:
                    if (string.IsNullOrEmpty(entity.Password?.NewPassword))
                        result.AddError(nameof(User.Password), "Password is required");
                    break;
                case CommonService.UpdateAction:
                    if (oldEntity.UserName != entity.UserName)
                        result.AddError(nameof(User.UserName), "User name is not allowed to update");
                    if (!string.IsNullOrEmpty(entity.Password?.NewPassword))
                        result.AddError(nameof(User.Password), "Please use change password function to change the password");
                    break;
                case CommonService.DeleteAction:
                    result.AddError("", "Delete operation is not supported");
                    return;
            }
            await Task.CompletedTask;
        }

        public async Task<User> GetUser(IUnitOfWork unitOfWork, string userName)
        {
            return await userRepository.GetByUserName(unitOfWork, userName);
        }

        public async Task<ServiceResult> ChangePassword(IUnitOfWork unitOfWork, ChangePasswordModel model)
        {
            ServiceResult result = new(ChangePasswordAction);
            var user = await GetUser(unitOfWork, unitOfWork.GetIdentity());
            if (!user.Password.CheckPassword(model.Password))
                result.AddError(nameof(ChangePasswordModel.Password), "Invalid password attempt");

            if (!result.Success) return result;

            user.Password.SetPassword(model.NewPassword);

            await userRepository.Update(unitOfWork, user, SaveOption.AutoSave);

            return result;
        }
    }
}
