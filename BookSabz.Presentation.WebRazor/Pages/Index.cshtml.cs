using BookSabz.Application.Contracts.BookApp;
using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Presentation.WebRazor.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TagHelpers.TagHelperModel;

namespace BookSabz.Presentation.WebRazor.Pages
{
    public class IndexModel : PageModel
    {

        public List<ViewBookTagHelperModel> PopularBook { get; set; }

        public List<ViewBookTagHelperModel> NewBook { get; set; }



        private readonly IBookApplication _book;

        private readonly IBookCategoryApplication _bookCategoory;

        public IndexModel(IBookApplication book, IBookCategoryApplication bookCategoory)
        {
            _book = book;
            _bookCategoory = bookCategoory;
        }


        public void OnGet()
        {


            PopularBook = GetBook.GetBookListExecutor(_book.GetLisProposede);
            NewBook = GetBook.GetBookListExecutorWithParameter<DateTime>(_book.GetListByDateTime, DateTime.Now.AddDays(-7));

        }
    }
}