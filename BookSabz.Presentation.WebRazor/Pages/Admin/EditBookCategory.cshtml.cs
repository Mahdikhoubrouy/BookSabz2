using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.BookCategory.Models;
using BookSabz.Presentation.WebRazor.PresentationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSabz.Presentation.WebRazor.Pages.Admin
{
	public class EditBookCategoryModel : PageModel
	{

		[BindProperty]
		public RenameBookCategory Category { get; set; }

		[TempData]
		public string ErrorMessage { get; set; }

		private readonly IBookCategoryApplication _bookCategoryApplication;

		public EditBookCategoryModel(IBookCategoryApplication bookCategoryApplication)
		{
			_bookCategoryApplication = bookCategoryApplication;
		}

		public async Task<IActionResult> OnGet(int id)
		{
			var bookcategory = await _bookCategoryApplication.Get(id);

			if (bookcategory == null)
				return NotFound();

			Category = bookcategory;

			return Page();
		}


		public async Task<IActionResult> OnPostRename(RenameBookCategory category)
		{
			if (!ModelState.IsValid)
			{
				ErrorMessage = "مقدار وارد شده درست نیست !";
				return Page();
			}
			await _bookCategoryApplication.Rename(category);

			return RedirectToPage("/Admin/BookCategoryList");
		}
	}
}
