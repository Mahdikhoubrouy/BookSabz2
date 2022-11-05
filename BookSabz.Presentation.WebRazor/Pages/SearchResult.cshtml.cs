using BookSabz.Application.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSabz.Presentation.WebRazor.Pages
{
    public class SearchResultModel : PageModel
    {
        public List<SearchViewModel> SearchResult { get; set; }

        private readonly ISearchApplication _searchApplication;


        public SearchResultModel(ISearchApplication searchApplication)
        {
            _searchApplication = searchApplication;
        }

        public RedirectToPageResult OnGet()
        {
            SearchResult = new List<SearchViewModel>();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostSearch(SearchModel Search)
        {
            if (!ModelState.IsValid)
                return RedirectToPage("/Index");

            try
            {
                SearchResult = _searchApplication.Search(Search);
            }
            catch
            {
                return RedirectToPage("/index");
            }
            return Page();
        }

    }
}
