using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
    public interface ICommonDbContext : IDbContext
    {
        DbSet<User> Users { get; set; }
    }
}
