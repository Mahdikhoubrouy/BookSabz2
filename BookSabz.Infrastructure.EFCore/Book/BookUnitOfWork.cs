using BookSabz.Domain.BookAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.BookRep
{
    public class BookUnitOfWork : IBookUnitOfWork
    {
        private readonly IReadBookRepository _readBookRepository;
        private readonly IWriteBookRepository _writeBookRepository;
        private readonly BookSabzContext _dbContext;

        public BookUnitOfWork(IReadBookRepository readBookRepository, IWriteBookRepository writeBookRepository, BookSabzContext dbContext)
        {
            _readBookRepository = readBookRepository;
            _writeBookRepository = writeBookRepository;
            _dbContext = dbContext;
        }

        public IReadBookRepository ReadBook => _readBookRepository;

        public IWriteBookRepository WriteBook => _writeBookRepository;

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
