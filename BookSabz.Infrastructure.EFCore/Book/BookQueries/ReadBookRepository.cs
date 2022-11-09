using AutoMapper;
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
        private readonly IMapper _mapper;

        public ReadBookRepository(BookSabzContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public List<BookListViewModel> GetListByCategoryName(string categoryName)
        {
            return _dbContext.Books.Include(x => x.BookCategory)
                .AsNoTracking()
                .Where(x => x.BookCategory.Name == categoryName)
                .Select(s => _mapper.Map<Book, BookListViewModel>(s))
                .ToList();
        }

        public BookViewModel GetByExpression(Expression<Func<Book, bool>> expression)
        {
            return _dbContext.Books.Include(x => x.BookCategory).Where(expression).Select(x => _mapper.Map<Book, BookViewModel>(x)).FirstOrDefault()!;
        }

        public BookViewModel GetById(long id)
        {
            return _dbContext.Books.Include(x => x.BookCategory).Where(x => x.Id == id)
                 .Select(s => _mapper.Map<Book, BookViewModel>(s)).SingleOrDefault()!;

		}

        public List<BookListViewModel> GetListByExpression(Expression<Func<Book, bool>> expression)
        {
            return _dbContext.Books.Include(x => x.BookCategory).AsNoTracking()
                .Where(expression)
                .Select(x => _mapper.Map<Book, BookListViewModel>(x)).ToList();

        }
    }
}
