using BookSabz.Core.Infrastructure.WriteRepository;
using BookSabz.Domain.BookAgg.Repository;
using BookSabz.Domain.BookCategoryAgg;
using BookSabz.Domain.BookCategoryAgg.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.BookCategoryRepo.BookCategoryCommand
{
    public class WriteBookCategoryRepository : WriteRepositoryBase<BookCategory, int>, IWriteBookCategoryRepository
    {
        private readonly BookSabzContext _dbContext;
        public WriteBookCategoryRepository(BookSabzContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
