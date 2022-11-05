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

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Any(expression);
        }

        public async Task<List<T>> GetAllAsNoTrackingAsync()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public async Task<T> GetAsync(Tkey id)
        {
            return await _dbContext.FindAsync<T>(id);
        }


    }
}
