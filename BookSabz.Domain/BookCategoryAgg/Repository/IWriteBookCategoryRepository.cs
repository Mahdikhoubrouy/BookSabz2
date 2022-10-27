using BookSabz.Core.Infrastructure.WriteRepository;

namespace BookSabz.Domain.BookCategoryAgg.Repository
{
    public interface IWriteBookCategoryRepository : IWriteRepository<BookCategory,int>
    {
        
    }
}
