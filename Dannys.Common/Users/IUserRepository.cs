using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common.Users
{
    public interface IUserRepository : IRootRepository<User>
    {
        Task<User> GetByUserName(IUnitOfWork unitOfWork, string userName);
    }
}
