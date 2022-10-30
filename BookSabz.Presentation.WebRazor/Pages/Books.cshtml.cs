using BookSabz.Application.Contracts.BookApp;
using BookSabz.Presentation.WebRazor.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TagHelpers.TagHelperModel;

namespace BookSabz.Presentation.WebRazor.Pages
{
    public class BooksModel : PageModel
    {

        public List<ViewBookTagHelperModel> historical { get; set; }

        public List<ViewBookTagHelperModel> philosophical { get; set; }

        public List<ViewBookTagHelperModel> Course { get; set; }

        public List<ViewBookTagHelperModel> Religious { get; set; }

        public List<ViewBookTagHelperModel> Psychology { get; set; }

        public List<ViewBookTagHelperModel> General { get; set; }


        private readonly IBookApplication _book;

        public BooksModel(IBookApplication book)
        {
            _book = book;
        }

        public void OnGet()
        {
            historical = GetBook.GetBookListExecutorWithParameter<string>(_book.GetListByCategoryName, "تاریخی");
            philosophical = GetBook.GetBookListExecutorWithParameter<string>(_book.GetListByCategoryName, "فلسفی");
            Course = GetBook.GetBookListExecutorWithParameter<string>(_book.GetListByCategoryName, "درسی");
            Religious = GetBook.GetBookListExecutorWithParameter<string>(_book.GetListByCategoryName, "دینی");
            Psychology = GetBook.GetBookListExecutorWithParameter<string>(_book.GetListByCategoryName, "روانشناسی");
            General = GetBook.GetBookListExecutorWithParameter<string>(_book.GetListByCategoryName, "عمومی");
        }
    }
}
