using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.BookCategory.Models;
using BookSabz.Presentation.WebRazor.Helpers;
using BookSabz.Presentation.WebRazor.PresentationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSabz.Pages.Admin
{
    public class CreateCategoryModel : PageModel
    {

        private readonly AuthAdmin _auth;


        public CreateBookCategoryPresentationModel Category { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        private readonly IBookCategoryApplication _bookCategoryApplication;

        public CreateCategoryModel(IBookCategoryApplication bookCategoryApplication, AuthAdmin auth)
        {
            _bookCategoryApplication = bookCategoryApplication;
            _auth = auth;
        }


        public IActionResult OnGet()
        {
            var isLogin = _auth.CheckLogin();
            if (!isLogin)
                return RedirectToPage("/Admin/Login");
            return Page();
        }

        public IActionResult OnPostCreate(CreateBookCategoryPresentationModel category)
        {
            var isLogin = _auth.CheckLogin();
            if (!isLogin)
                return RedirectToPage("/Admin/Login");

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
