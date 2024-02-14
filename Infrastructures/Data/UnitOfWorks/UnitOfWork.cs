using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Context;
using Infrastructures.Data.Repositories;

namespace Infrastructures.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserCrudDbContext _dbContext;
        private IUserRepository _userRepository;

        public UnitOfWork(UserCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_dbContext); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}