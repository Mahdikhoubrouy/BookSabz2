using BookSabz.Core.Infrastructure.WriteRepository;
using BookSabz.Domain.BookAgg;
using BookSabz.Domain.BookAgg.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.BookRepo.BookCommand
{
    public class WriteBookRepository : WriteRepositoryBase<Book, long>, IWriteBookRepository
    {
        private readonly BookSabzContext _dbContext;

        public WriteBookRepository(BookSabzContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
