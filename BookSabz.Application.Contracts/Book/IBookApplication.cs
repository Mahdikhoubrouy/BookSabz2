using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookSabz.Application.Contracts.Book.Models;

namespace BookSabz.Application.Contracts.BookApp
{
    public interface IBookApplication
    {
        List<BookListViewModel> GetListByCategoryName(string CategoryName);

        List<BookListViewModel> GetListByDateTime(DateTime dateTime);

        List<BookListViewModel> GetLisProposede();

        List<BookListViewModel> GetListLast();

        BookViewModel GetById(long id);

        void Create(CreateBook command);
        
        void Edit(EditBook command);

        void Delete(long id);

        void UnDelete(long id);

        void Visible(long id);

        void UnVisible(long id);

    }
}
