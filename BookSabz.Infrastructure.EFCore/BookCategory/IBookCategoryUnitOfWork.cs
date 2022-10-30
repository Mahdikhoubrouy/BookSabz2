using BookSabz.Domain.BookAgg.Repository;
using BookSabz.Domain.BookCategoryAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.BookRep
{
    public interface IBookCategoryUnitOfWork
    {
        public IReadBookCategoryRepository ReadBookCategory { get; }
        public IWriteBookCategoryRepository WriteBookCategory { get; }
        public void SaveChanges();
    }
}
