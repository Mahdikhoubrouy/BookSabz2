using AutoMapper;
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
        private readonly IMapper _mapper;

        public BookViewModel Book { get; set; }
        public List<ViewBookTagHelperModel> SimilarBooks { get; set; }
        public List<ViewBookTagHelperModel> SuggestedBooks { get; set; }


        public Book_DetailsModel(IBookApplication bookApplication, IMapper mapper)
        {
            _bookApplication = bookApplication;
            _mapper = mapper;
        }

        public IActionResult OnGet(long id)
        {
            Book = _bookApplication.GetById(id);
            SimilarBooks = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_bookApplication.GetListByCategoryName(Book.CategoryName));
            SuggestedBooks = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_bookApplication.GetLisProposede());

            if (Book == null)
                return NotFound();
            return Page();
        }
    }
}
