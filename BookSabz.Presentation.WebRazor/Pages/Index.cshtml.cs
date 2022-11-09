using AutoMapper;
using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Application.Contracts.BookApp;
using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Domain.BookAgg;
using BookSabz.Infrastructure.EFCore;
using BookSabz.Presentation.WebRazor.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using TagHelpers.TagHelperModel;

namespace BookSabz.Presentation.WebRazor.Pages
{
    public class IndexModel : PageModel
    {
        // TODO : this section added book list with options => (Edit , Delete)
        public List<ViewBookTagHelperModel> PopularBook { get; set; }

        public List<ViewBookTagHelperModel> NewBook { get; set; }


        private readonly IBookApplication _book;
        private readonly IMapper _mapper;



        public IndexModel(IBookApplication book, IMapper mapper)
        {
            _book = book;
            _mapper = mapper;
        }


        public void OnGet()
        {
            PopularBook = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetLisProposede());

            NewBook = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetListByDateTime(DateTime.Now.AddDays(-7)));

        }
    }
}