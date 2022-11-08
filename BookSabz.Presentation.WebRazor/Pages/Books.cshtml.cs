using AutoMapper;
using BookSabz.Application.Contracts.Book.Models;
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
        private readonly IMapper _mapper;

        public BooksModel(IBookApplication book, IMapper mapper)
        {
            _book = book;
            _mapper = mapper;
        }

        public void OnGet()
        {
            historical = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetListByCategoryName("تاریخی"));
            philosophical = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetListByCategoryName("فلسفی"));
            Course = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetListByCategoryName("درسی"));
            Religious = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetListByCategoryName("دینی"));
            Psychology = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetListByCategoryName("روانشناسی"));
            General = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetListByCategoryName("عمومی"));
        }
    }
}
