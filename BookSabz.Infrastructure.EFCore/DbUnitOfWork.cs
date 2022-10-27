using BookSabz.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookSabz.Infrastructure.EFCore
{
    public class DbUnitOfWork : IDbUnitOfWork
    {
        private readonly BookSabzContext _dbContext;


        public DbUnitOfWork(BookSabzContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTran()
        {
            _dbContext.Database.BeginTransaction();
        }



        public void CommitTran()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}
