using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.BookCategory.Models;
using BookSabz.Presentation.Web.PresentationModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSabz.Pages.Admin
{
    [Authorize]
    public class CreateCategoryModel : PageModel
    {
        public CreateBookCategoryPresentationModel Category { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        private readonly IBookCategoryApplication _bookCategoryApplication;

        public CreateCategoryModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }

 
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostCreate(CreateBookCategoryPresentationModel category)
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "مقدار وارد شده معتبر نیست";
                return Page();
            }


            try
            {
                _bookCategoryApplication.Create(new CreateBookCategory
                {
                    Name = category.CategoryName
                });
            }
            catch 
            {
                ErrorMessage = "نام وارد شده تکراری است";
                return Page();
            }
            return RedirectToPage("/Admin/CreateCategory");
        }
    }
}
