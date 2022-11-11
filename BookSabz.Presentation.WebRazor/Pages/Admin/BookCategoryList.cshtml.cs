using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.BookCategory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace BookSabz.Presentation.WebRazor.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class BookCategoryListModel : PageModel
    {
        private readonly IBookCategoryApplication _bookCategory;

		public BookCategoryListModel(IBookCategoryApplication bookCategory)
		{
			_bookCategory = bookCategory;
		}


        public List<BookCategoryViewModel> Categories { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Categories = await _bookCategory.GetListAsync();

            return Page();
        }


        public async Task<IActionResult> OnGetRestore(int id)
        {
            await _bookCategory.UnDelete(id);

            return RedirectToPage("./BookCategoryList");

        }


        public async Task<IActionResult> OnGetDelete(int id)
        {
            await _bookCategory.Delete(id);

            return RedirectToPage("./BookCategoryList");

        }
    }
}
