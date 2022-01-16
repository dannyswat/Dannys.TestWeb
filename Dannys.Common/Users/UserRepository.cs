using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common.Users
{
    public class UserRepository : EFRootRepository<User, IUserDbContext>, IUserRepository
    {
        public async Task<User> GetByUserName(IUnitOfWork unitOfWork, string userName)
        {
            var dbContext = GetDbContext(unitOfWork);
            return await dbContext.Users.Where(r => r.UserName == userName).FirstOrDefaultAsync();
        }
    }
}
