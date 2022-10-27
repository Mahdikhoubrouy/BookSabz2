using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Core.Infrastructure.ReadRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Domain.BookAgg.Repository
{
    public interface IReadBookRepository : IReadRepository<long, Book>
    {
        BookViewModel GetById(long id);
        List<BookListViewModel> GetListByCategoryName(string categoryName);
        List<BookListViewModel> GetListByExpression(Expression<Func<Book, bool>> expression);
        BookViewModel GetByExpression(Expression<Func<Book, bool>> expression);
    }
}
