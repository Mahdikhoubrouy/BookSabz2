using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Application.Contracts.BookApp;
using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.BookCategory.Models;
using BookSabz.Presentation.WebRazor.AdminModel;
using BookSabz.Presentation.WebRazor.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSabz.Pages.Admin
{
    public class CreateBookModel : PageModel
    {
        [BindProperty]
        public CreateBookPresentationModel Book { get; set; }

        public List<BookCategoryViewModel> Categories { get; set; }

        private readonly IBookCategoryApplication _bookCategoryApplication;
        private readonly IBookApplication _bookApplication;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment { get; set; }
        private readonly AuthAdmin _auth;

        public CreateBookModel(IBookCategoryApplication bookCategoryApplication, IBookApplication bookApplication, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, AuthAdmin auth)
        {
            _bookCategoryApplication = bookCategoryApplication;
            _bookApplication = bookApplication;
            _environment = environment;
            _auth = auth;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var isLogin = _auth.CheckLogin();
            if (!isLogin)
                return RedirectToPage("/Admin/Login");

            Categories = await _bookCategoryApplication.GetListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostCreate(CreateBookPresentationModel Book)
        {
            var isLogin = _auth.CheckLogin();
            if (!isLogin)
                return RedirectToPage("/Admin/Login");


            if (!ModelState.IsValid)
            {
                ErrorMessage = "مقادیر وارد شده صحیح نمی باشد";
                Categories = await _bookCategoryApplication.GetListAsync();
                return Page();
            }
            string fileNameImage = Guid.NewGuid() + ".jpg";
            string fileNameBook = Guid.NewGuid() + Path.GetExtension(Book.BookFile.FileName);
            string fileImage = Path.Combine(_environment.ContentRootPath, "wwwroot","Books", "images", fileNameImage);
            string fileBook = Path.Combine(_environment.ContentRootPath, "wwwroot","Books", "Downloads", "Books", fileNameBook);
            await WriteAndCreateFile(fileImage,Book.Image);
            await WriteAndCreateFile(fileBook,Book.BookFile);

            try
            {
                _bookApplication.Create(new CreateBook()
                {
                    Name = Book.Name,
                    Author = Book.Author,
                    BookCategoryId = Book.CategoryId,
                    Description = Book.Description,
                    FilePath = fileNameBook,
                    ImagePath = fileNameImage,
                    PublishYear = Book.PublishYear,

                });

            }
            catch
            {

                ErrorMessage = "مشکلی پیش آمده ، مقدار وارد شده احتمالا درست نیست";
                Categories = await _bookCategoryApplication.GetListAsync();
                return Page();
            }

            return RedirectToPage("/Admin/CreateBook");
        }

        private async Task WriteAndCreateFile(string pathStream,IFormFile file)
        {

            using (var stream = System.IO.File.Create(pathStream))
            {
                await file.CopyToAsync(stream);
            }

        }
    }
}
