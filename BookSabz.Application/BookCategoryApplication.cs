using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.BookCategory.Models;
using BookSabz.Core.Infrastructure;
using BookSabz.Domain.BookCategoryAgg;
using BookSabz.Domain.BookCategoryAgg.Services;
using BookSabz.Infrastructure.EFCore.BookRep;

namespace BookSabz.Application
{
    public class BookCategoryApplication : IBookCategoryApplication
    {
        private readonly IBookCategoryUnitOfWork _bookCategoryUnitOfWork;
        private readonly IBookCategoryValidatorService _bookCategoryValidatorService;

        public BookCategoryApplication(IBookCategoryUnitOfWork bookCategoryUnitOfWork, IBookCategoryValidatorService bookCategoryValidatorService)
        {
            _bookCategoryUnitOfWork = bookCategoryUnitOfWork;
            _bookCategoryValidatorService = bookCategoryValidatorService;
        }

        public void Create(CreateBookCategory command)
        {
            _bookCategoryUnitOfWork.WriteBookCategory.Create(new BookCategory(command.Name, _bookCategoryValidatorService));
            _bookCategoryUnitOfWork.SaveChanges();
        }

        public async void Delete(int id)
        {
            var bookCategory = await _bookCategoryUnitOfWork.ReadBookCategory.GetAsync(id);
            bookCategory.Delete();
            _bookCategoryUnitOfWork.SaveChanges();

        }

        public async Task<RenameBookCategory> Get(int id)
        {
            var bookCategory = await _bookCategoryUnitOfWork.ReadBookCategory.GetAsync(id);

            return new RenameBookCategory
            {
                Id = bookCategory.Id,
                Name = bookCategory.Name
            };

        }

        public async Task<List<BookCategoryViewModel>> GetListAsync()
        {
            var bookCategories = await _bookCategoryUnitOfWork.ReadBookCategory.GetAllAsNoTrackingAsync();

            return bookCategories.Select(x => new BookCategoryViewModel
            {
                CreationDate = x.CreationDate.ToString(),
                Id = x.Id,
                IsDeleted = x.IsDeleted,
                Name = x.Name,

            }).ToList();
        }

        public async Task Rename(RenameBookCategory command)
        {

            var bookCategory = await _bookCategoryUnitOfWork.ReadBookCategory.GetAsync(command.Id);
            bookCategory.Rename(command.Name);
            _bookCategoryUnitOfWork.SaveChanges();
        }

        public async void UnDelete(int id)
        {

            var bookCategory = await _bookCategoryUnitOfWork.ReadBookCategory.GetAsync(id);
            bookCategory.UnDelete();
            _bookCategoryUnitOfWork.SaveChanges();
        }

    }
}
