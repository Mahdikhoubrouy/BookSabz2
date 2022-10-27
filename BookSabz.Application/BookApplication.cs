using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Application.Contracts.BookApp;
using BookSabz.Core.Infrastructure;
using BookSabz.Domain.BookAgg;
using BookSabz.Domain.BookAgg.Services;
using BookSabz.Infrastructure.EFCore.BookRep;


namespace BookSabz.Application
{
    public class BookApplication : IBookApplication
    {

        private readonly IBookUnitOfWork _bookUnitOfWork;
        private readonly IDbUnitOfWork _dbTranUnitOfWork;

        private readonly IBookValidatorService _bookValidatorService;

        public BookApplication(IBookUnitOfWork bookUnitOfWork, IDbUnitOfWork dbTranUnitOfWork, IBookValidatorService bookValidatorService)
        {
            _bookUnitOfWork = bookUnitOfWork;
            _dbTranUnitOfWork = dbTranUnitOfWork;
            _bookValidatorService = bookValidatorService;
        }


        #region Command

        public void Create(CreateBook command)
        {
            _dbTranUnitOfWork.BeginTran();

            _bookUnitOfWork.WriteBook.Create(new Book(command.Name, command.ImagePath, command.Author, command.PublishYear
            , command.FilePath, command.Description, command.BookCategoryId, _bookValidatorService));
            _dbTranUnitOfWork.SaveChange();
            _dbTranUnitOfWork.CommitTran();


        }

        public async void Edit(EditBook command)
        {
            _dbTranUnitOfWork.BeginTran();

            var book = await _bookUnitOfWork.ReadBook.GetAsync(command.Id);
            book.Edit(command.Name, command.ImagePath, command.Author, command.PublishYear, command.FilePath, command.Description);
            _dbTranUnitOfWork.SaveChange();
            _dbTranUnitOfWork.CommitTran();


        }


        #endregion

        #region Query
        public BookViewModel GetById(long id)
        {
            return _bookUnitOfWork.ReadBook.GetById(id);
        }

        public List<BookListViewModel> GetLisProposede()
        {
            return _bookUnitOfWork.ReadBook.GetListByExpression(x => x.DownloadCount == 0);
        }

        public List<BookListViewModel> GetListByCategoryName(string CategoryName)
        {
            return _bookUnitOfWork.ReadBook.GetListByCategoryName(CategoryName);
        }

        public List<BookListViewModel> GetListByDateTime(DateTime dateTime)
        {
            return _bookUnitOfWork.ReadBook.GetListByExpression(x => x.CreationDate > dateTime);
        }

        public List<BookListViewModel> GetListLast()
        {
            return _bookUnitOfWork.ReadBook.GetListByExpression(x => x.CreationDate > DateTime.Now.AddDays(-7));
        }

        #endregion

        #region Command Activity


        public async void Delete(long id)
        {
            _dbTranUnitOfWork.BeginTran();

            var book = await _bookUnitOfWork.ReadBook.GetAsync(id);
            book.Delete();
            _dbTranUnitOfWork.SaveChange();

            _dbTranUnitOfWork.CommitTran();

        }
        public async void UnDelete(long id)
        {
            _dbTranUnitOfWork.BeginTran();

            var book = await _bookUnitOfWork.ReadBook.GetAsync(id);

            book.UnDelete();

            _dbTranUnitOfWork.SaveChange();
            _dbTranUnitOfWork.CommitTran();
        }

        public async void UnVisible(long id)
        {
            _dbTranUnitOfWork.BeginTran();

            var book = await _bookUnitOfWork.ReadBook.GetAsync(id);

            book.UnVisible();

            _dbTranUnitOfWork.SaveChange();
            _dbTranUnitOfWork.CommitTran();
        }

        public async void Visible(long id)
        {
            _dbTranUnitOfWork.BeginTran();

            var book = await _bookUnitOfWork.ReadBook.GetAsync(id);

            book.Visible();

            _dbTranUnitOfWork.SaveChange();
            _dbTranUnitOfWork.CommitTran();
        }

        #endregion


    }
}
