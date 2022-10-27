using BookSabz.Application.Contracts.BookApp;
using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Presentation.Web.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TagHelpers.TagHelperModel;

namespace BookSabz.Presentation.Web.Pages
{
    public class IndexModel : PageModel
    {

        public List<ViewBookTagHelperModel> PopularBook { get; set; }

        public List<ViewBookTagHelperModel> NewBook { get; set; }


        

        private readonly ILogger<IndexModel> _logger;

        private readonly IBookApplication _book;

        private readonly IBookCategoryApplication _bookCategoory;

        private readonly RoleManager<IdentityRole> role;
        public IndexModel(ILogger<IndexModel> logger, IBookApplication book, IBookCategoryApplication bookCategoory, RoleManager<IdentityRole> role)
        {
            _logger = logger;
            _book = book;
            _bookCategoory = bookCategoory;
            this.role = role;
        }

        public async void OnGet()
        { 

            PopularBook = GetBook.GetBookListExecutor(_book.GetLisProposede);
            NewBook = GetBook.GetBookListExecutorWithParameter<DateTime>(_book.GetListByDateTime, DateTime.Now.AddDays(-7));

            await role.CreateAsync(new IdentityRole("fgfg"));

        }
    }
}