﻿using BookSabz.Application.Contracts.Book.Models;
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

        private readonly IBookValidatorService _bookValidatorService;

        public BookApplication(IBookUnitOfWork bookUnitOfWork, IBookValidatorService bookValidatorService)
        {
            _bookUnitOfWork = bookUnitOfWork;
            _bookValidatorService = bookValidatorService;

        }
        #region Command

        public void Create(CreateBook command)
        {

            _bookUnitOfWork.WriteBook.Create(new Book(command.Name, command.ImagePath, command.Author, command.PublishYear
            , command.FilePath, command.Description, command.BookCategoryId, _bookValidatorService));

            _bookUnitOfWork.SaveChanges();

        }

        public async void Edit(EditBook command)
        {

            var book = await _bookUnitOfWork.ReadBook.GetAsync(command.Id);
            book.Edit(command.Name, command.ImagePath, command.Author, command.PublishYear, command.FilePath, command.Description,command.BookCategoryId);

            _bookUnitOfWork.SaveChanges();
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
            var book = await _bookUnitOfWork.ReadBook.GetAsync(id);
            book.Delete();
            _bookUnitOfWork.SaveChanges();

        }
        public async void UnDelete(long id)
        {
            var book = await _bookUnitOfWork.ReadBook.GetAsync(id);

            book.UnDelete();

            _bookUnitOfWork.SaveChanges();
        }

        public async void UnVisible(long id)
        {

            var book = await _bookUnitOfWork.ReadBook.GetAsync(id);

            book.UnVisible();

            _bookUnitOfWork.SaveChanges();
        }

        public async void Visible(long id)
        {

            var book = await _bookUnitOfWork.ReadBook.GetAsync(id);

            book.Visible();

            _bookUnitOfWork.SaveChanges();
        }

        #endregion


    }
}
