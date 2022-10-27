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


        public BookUnitOfWork(IReadBookRepository readBookRepository, IWriteBookRepository writeBookRepository)
        {
            _readBookRepository = readBookRepository;
            _writeBookRepository = writeBookRepository;
        }

        public IReadBookRepository ReadBook => _readBookRepository;

        public IWriteBookRepository WriteBook => _writeBookRepository;
    }
}
