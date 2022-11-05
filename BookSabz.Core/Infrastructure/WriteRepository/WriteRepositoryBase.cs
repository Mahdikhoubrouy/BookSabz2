using BookSabz.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Core.Infrastructure.WriteRepository
{
    public class WriteRepositoryBase<T, TKey> : IWriteRepository<T, TKey> where T : DomainBase<TKey>
    {
        private readonly DbContext _dbContext;

        public WriteRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);

        }
    }
}
