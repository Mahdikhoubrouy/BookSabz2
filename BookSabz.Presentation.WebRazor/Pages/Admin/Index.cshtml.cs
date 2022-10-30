using BookSabz.Presentation.WebRazor.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSabz.Pages.Admin
{
    public class IndexModel : PageModel
    {

        private readonly AuthAdmin _auth;

        public IndexModel(AuthAdmin auth)
        {
            _auth = auth;
        }

        public IActionResult OnGet()
        {
            var isLogin = _auth.CheckLogin();
            if (!isLogin)
                return RedirectToPage("/Admin/Login");

            return Page();
        }
    }
}
