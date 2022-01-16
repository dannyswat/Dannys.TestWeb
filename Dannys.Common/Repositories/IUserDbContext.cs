﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common.Repositories
{
    public interface IUserDbContext : IDbContext
    {
        DbSet<User> Users { get; set; }
    }
}
