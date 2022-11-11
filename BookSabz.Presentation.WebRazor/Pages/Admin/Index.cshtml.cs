using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Application.Contracts.BookApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSabz.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        public List<BookManagementModel> Books { get; set; }

        private readonly IBookApplication _book;

        public IndexModel(IBookApplication book)
        {
            _book = book;
        }

        public IActionResult OnGet()
        {
            Books = _book.GetAll();
            return Page();

        }

        public async Task<IActionResult> OnGetRestore(long id)
        {
            await _book.UnDelete(id);
            return RedirectToPage("/Admin/Index");
        }

        public async Task<IActionResult> OnGetDelete(long id)
        {
            await _book.Delete(id);
            return RedirectToPage("/Admin/Index");
        }

        public async Task<IActionResult> OnGetUnvisible(long id)
        {
            await _book.UnVisible(id);
            return RedirectToPage("/Admin/Index");
        }

        public async Task<IActionResult> OnGetVisible(long id)
        {
            await _book.Visible(id);
            return RedirectToPage("/Admin/Index");
        }
    }
}
