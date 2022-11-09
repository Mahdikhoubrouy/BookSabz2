using BookSabz.Core.Infrastructure.ReadRepository;
using BookSabz.Domain.BookCategoryAgg;
using BookSabz.Domain.BookCategoryAgg.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.BookCategoryRepo.BookCategoryQueries
{
    public class ReadBookCategoryRepository : ReadRepositoryBase<int, BookCategory>, IReadBookCategoryRepository
    {
        private readonly BookSabzContext _dbContext;
        public ReadBookCategoryRepository(BookSabzContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

		public async Task<BookCategory> GetByName(string name)
		{
           return await _dbContext.BookCategories.SingleOrDefaultAsync(x => x.Name == name)!;
		}
	}
}
