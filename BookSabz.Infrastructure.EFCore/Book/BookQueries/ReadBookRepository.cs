using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Core.Infrastructure.ReadRepository;
using BookSabz.Domain.BookAgg;
using BookSabz.Domain.BookAgg.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookSabz.Infrastructure.EFCore.BookRep.BookQueries
{
    public class ReadBookRepository : ReadRepositoryBase<long, Book>, IReadBookRepository
    {
        private readonly BookSabzContext _dbContext;

        public ReadBookRepository(BookSabzContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookListViewModel> GetListByCategoryName(string categoryName)
        {
            return _dbContext.Books.Include(x => x.BookCategory)
                .Where(x => x.BookCategory.Name == categoryName)
                .Select(x => new BookListViewModel
                {
                    Author = x.Author,
                    ImagePath = x.ImagePath,
                    Name = x.Name
                }).ToList();
        }

        public BookViewModel GetByExpression(Expression<Func<Book, bool>> expression)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _dbContext.Books.Include(x => x.BookCategory).Where(expression).Select(x => new BookViewModel
            {
                Id = x.Id,
                Description = x.Description,
                FilePath = x.FilePath,
                ImagePath = x.ImagePath,
                Name = x.Name,
                PublishYear = x.PublishYear,
                Author = x.Author
            }).SingleOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public BookViewModel GetById(long id)
        {
            return _dbContext.Books.Include(x=>x.BookCategory).Where(x => x.Id == id)
                 .Select(x => new BookViewModel
                 {
                     Id = x.Id,
                     Description = x.Description,
                     FilePath = x.FilePath,
                     ImagePath = x.ImagePath,
                     Name = x.Name,
                     PublishYear = x.PublishYear,
                     Author = x.Author,
                     CategoryName = x.BookCategory.Name
                     
                 }).SingleOrDefault()!;
        }

        public List<BookListViewModel> GetListByExpression(Expression<Func<Book, bool>> expression)
        {
            return _dbContext.Books.Include(x => x.BookCategory)
                .Where(expression)
                .Select(x => new BookListViewModel
                {
                    Id = x.Id,
                    Author = x.Author,
                    ImagePath = x.ImagePath,
                    Name = x.Name
                }).ToList();

        }
    }
}
