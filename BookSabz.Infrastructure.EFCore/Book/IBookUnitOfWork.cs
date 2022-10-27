using BookSabz.Domain.BookAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.BookRep
{
    public interface IBookUnitOfWork
    {
        public IReadBookRepository ReadBook { get; }
        public IWriteBookRepository WriteBook { get; }

    }
}
