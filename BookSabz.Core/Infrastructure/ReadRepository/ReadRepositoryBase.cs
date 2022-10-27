using BookSabz.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Core.Infrastructure.ReadRepository
{
    public class ReadRepositoryBase<Tkey, T> : IReadRepository<Tkey, T> where T : DomainBase<Tkey>
    {
        private readonly DbContext _dbContext;

        public ReadRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AnyAsync(expression);
        }

        public async Task<List<T>> GetAllAsNoTrackingAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Tkey id)
        {
            return await _dbContext.FindAsync<T>(id);
        }


    }
}
