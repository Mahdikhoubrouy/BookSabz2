using BookSabz.Application.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSabz.Presentation.Web.Pages
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
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostSearch(SearchModel Search)
        {
            if (!ModelState.IsValid)
                return RedirectToPage("/Index");

            SearchResult = _searchApplication.Search(Search);
            return Page();
        }

    }
}
