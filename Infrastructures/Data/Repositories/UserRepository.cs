using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructures.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserCrudDbContext _dbContext;

        public UserRepository(UserCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Entry(user).State = EntityState.Detached;
            }
            return user;
        }

        public void Update(User user)
        {
            _dbContext.Users.Update(user);
        }
    }
}