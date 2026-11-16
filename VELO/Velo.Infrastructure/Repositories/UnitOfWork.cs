using System;
using System.Collections.Generic;
using System.Text;
using Velo.Application.Interfaces.Repo;
using Velo.Infrastructure.Persistence.AppDbContext;

namespace Velo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VeloDbContext _context;
        public UnitOfWork(VeloDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
