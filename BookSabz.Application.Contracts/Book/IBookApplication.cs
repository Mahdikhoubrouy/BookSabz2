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

        List<BookManagementModel> GetAll();

        BookViewModel GetById(long id);

        void Create(CreateBook command);
        
        Task Edit(EditBook command);

        Task Delete(long id);

        Task UnDelete(long id);

        Task Visible(long id);

        Task UnVisible(long id);

    }
}
