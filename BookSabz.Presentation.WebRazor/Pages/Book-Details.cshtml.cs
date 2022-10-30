using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Application.Contracts.BookApp;
using BookSabz.Domain.BookAgg;
using BookSabz.Presentation.WebRazor.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TagHelpers.TagHelperModel;

namespace BookSabz.Pages
{
    public class Book_DetailsModel : PageModel
    {
        private readonly IBookApplication _bookApplication;

        public BookViewModel Book { get; set; }
        public List<ViewBookTagHelperModel> SimilarBooks { get; set; }
        public List<ViewBookTagHelperModel> SuggestedBooks { get; set; }

        public Book_DetailsModel(IBookApplication bookApplication)
        {
            _bookApplication = bookApplication;
        }

        public IActionResult OnGet(long id)
        {
            Book = _bookApplication.GetById(id);
            SimilarBooks = GetBook.GetBookListExecutorWithParameter<string>(_bookApplication.GetListByCategoryName, Book.CategoryName);
            SuggestedBooks = GetBook.GetBookListExecutor(_bookApplication.GetLisProposede);
            if (Book == null)
                return NotFound();
            return Page();
        }
    }
}
