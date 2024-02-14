using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Data.Repositories;

namespace Infrastructures.Data.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}