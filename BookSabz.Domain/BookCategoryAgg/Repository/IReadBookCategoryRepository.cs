using BookSabz.Core.Infrastructure.ReadRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Domain.BookCategoryAgg.Repository
{
    public interface IReadBookCategoryRepository : IReadRepository<int,BookCategory>
    {
    }
}
