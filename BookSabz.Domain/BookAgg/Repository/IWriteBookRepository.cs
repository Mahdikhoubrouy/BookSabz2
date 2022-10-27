using BookSabz.Core.Infrastructure.WriteRepository;

namespace BookSabz.Domain.BookAgg.Repository
{
    public interface IWriteBookRepository : IWriteRepository<Book,long>
    {

    }
}
