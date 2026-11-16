using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velo.Application.Interfaces.Repo;
using Velo.Application.Specifications;
using Velo.Infrastructure.Evaluator;
using Velo.Infrastructure.Persistence.AppDbContext;
namespace Velo.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly VeloDbContext _context;
        private readonly DbSet<T> _dbset;
        public GenericRepository(VeloDbContext storeDbContext)
        {
            _context = storeDbContext;
            _dbset = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<int> CountWithSpecAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            return await SpecificationEvaluator
                 .GetCountQuery(_context.Set<T>(), spec)
                 .CountAsync(cancellationToken);
        }
        public async Task<T?> GetbyIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
        }

        public async Task<List<T>> GetAllWithSpecAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            return await SpecificationEvaluator.
                            GetQuery(_context.Set<T>(), spec).
                            AsNoTracking().
                            ToListAsync(cancellationToken);
        }

        public async Task<T?> GetFirstOrDefaultWithSpecAsync(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            return await SpecificationEvaluator.
                         GetQuery(_context.Set<T>(), spec).
                         FirstOrDefaultAsync();
        }
    }
}
