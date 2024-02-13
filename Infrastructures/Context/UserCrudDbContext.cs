using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Context
{
    public class UserCrudDbContext : DbContext
    {
        public UserCrudDbContext(DbContextOptions<UserCrudDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}