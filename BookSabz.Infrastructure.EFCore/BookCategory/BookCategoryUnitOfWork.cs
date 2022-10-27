using BookSabz.Domain.BookCategoryAgg.Repository;
using BookSabz.Infrastructure.EFCore.BookRep;

namespace BookSabz.Infrastructure.EFCore.BookCategoeryRepo
{
    public class BookCategoryUnitOfWork : IBookCategoryUnitOfWork
    {
        private readonly IReadBookCategoryRepository _readBookCategoryRepository;
        private readonly IWriteBookCategoryRepository _writeBookCategoryRepository;

        public BookCategoryUnitOfWork(IReadBookCategoryRepository readBookCategoryRepository, IWriteBookCategoryRepository writeBookCategoryRepository)
        {
            _readBookCategoryRepository = readBookCategoryRepository;
            _writeBookCategoryRepository = writeBookCategoryRepository;
        }

        public IReadBookCategoryRepository ReadBookCategory => _readBookCategoryRepository;

        public IWriteBookCategoryRepository WriteBookCategory => _writeBookCategoryRepository;
    }
}
