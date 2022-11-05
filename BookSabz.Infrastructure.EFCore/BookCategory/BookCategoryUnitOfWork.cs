using BookSabz.Domain.BookCategoryAgg.Repository;
using BookSabz.Infrastructure.EFCore.BookRep;

namespace BookSabz.Infrastructure.EFCore.BookCategoeryRepo
{
    public class BookCategoryUnitOfWork : IBookCategoryUnitOfWork
    {
        private readonly IReadBookCategoryRepository _readBookCategoryRepository;
        private readonly IWriteBookCategoryRepository _writeBookCategoryRepository;

        private readonly BookSabzContext _dbContext;
        public BookCategoryUnitOfWork(IReadBookCategoryRepository readBookCategoryRepository, IWriteBookCategoryRepository writeBookCategoryRepository, BookSabzContext dbContext)
        {
            _readBookCategoryRepository = readBookCategoryRepository;
            _writeBookCategoryRepository = writeBookCategoryRepository;
            _dbContext = dbContext;
        }

        public IReadBookCategoryRepository ReadBookCategory => _readBookCategoryRepository;

        public IWriteBookCategoryRepository WriteBookCategory => _writeBookCategoryRepository;

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
