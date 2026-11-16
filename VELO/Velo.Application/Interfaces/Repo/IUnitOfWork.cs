using System;
using System.Collections.Generic;
using System.Text;

namespace Velo.Application.Interfaces.Repo
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        Task<int> SaveChangesAsync();

    }
}
