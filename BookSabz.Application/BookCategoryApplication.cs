using AutoMapper;
using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.BookCategory.Models;
using BookSabz.Core.Infrastructure;
using BookSabz.Domain.BookCategoryAgg;
using BookSabz.Domain.BookCategoryAgg.BookCategoryException;
using BookSabz.Domain.BookCategoryAgg.Services;
using BookSabz.Infrastructure.EFCore.BookRep;
using Microsoft.Extensions.Logging;

namespace BookSabz.Application
{
    public class BookCategoryApplication : IBookCategoryApplication
    {
        private readonly IBookCategoryUnitOfWork _bookCategoryUnitOfWork;
        private readonly IBookCategoryValidatorService _bookCategoryValidatorService;
        private readonly ILogger<BookCategoryApplication> _logger;
        private readonly IMapper _mapper;

        public BookCategoryApplication(IBookCategoryUnitOfWork bookCategoryUnitOfWork, IBookCategoryValidatorService bookCategoryValidatorService, ILogger<BookCategoryApplication> logger, IMapper mapper)
        {
            _bookCategoryUnitOfWork = bookCategoryUnitOfWork;
            _bookCategoryValidatorService = bookCategoryValidatorService;
            _logger = logger;
            _mapper = mapper;
        }

        public void Create(CreateBookCategory command)
        {
            var book = new BookCategory(command.Name, _bookCategoryValidatorService);

            _bookCategoryUnitOfWork.WriteBookCategory.Create(book);

            _bookCategoryUnitOfWork.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var bookCategory = await _bookCategoryUnitOfWork.ReadBookCategory.GetAsync(id);
            bookCategory.Delete();
            _bookCategoryUnitOfWork.SaveChanges();

        }

        public async Task<RenameBookCategory> Get(int id)
        {
            var bookCategory = await _bookCategoryUnitOfWork.ReadBookCategory.GetAsync(id);

            return _mapper.Map<BookCategory, RenameBookCategory>(bookCategory);

        }

        public async Task<BookCategoryViewModel> GetByNameAsync(string name)
        {
            var category = await _bookCategoryUnitOfWork.ReadBookCategory.GetByName(name);

            return _mapper.Map<BookCategory, BookCategoryViewModel>(category);
        }

        public async Task<List<BookCategoryViewModel>> GetListAsync()
        {
            var bookCategories = await _bookCategoryUnitOfWork.ReadBookCategory.GetAllAsNoTrackingAsync();

            return bookCategories.Select(x => _mapper.Map<BookCategory, BookCategoryViewModel>(x)).ToList();
        }

        public async Task Rename(RenameBookCategory command)
        {

            var bookCategory = await _bookCategoryUnitOfWork.ReadBookCategory.GetAsync(command.Id);
            bookCategory.Rename(command.Name);
            _bookCategoryUnitOfWork.SaveChanges();
        }

        public async Task UnDelete(int id)
        {

            var bookCategory = await _bookCategoryUnitOfWork.ReadBookCategory.GetAsync(id);
            bookCategory.UnDelete();
            _bookCategoryUnitOfWork.SaveChanges();
        }

    }
}
