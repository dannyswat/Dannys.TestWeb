using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common.Repositories
{
    public class UserRepository : EFRootRepository<User, IUserDbContext>, IRootRepository<User>
    {

    }
}
