using BookSabz.Presentation.WebRazor.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSabz.Presentation.WebRazor.Pages.Admin
{
    public class LoginModel : PageModel
    {

        private readonly AuthAdmin _auth;

        [BindProperty]
        public AdminLoginModel AdminLogin { get; set; }


        public LoginModel(AuthAdmin auth)
        {
            _auth = auth;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(AdminLoginModel adminlogin)
        {
            if (ModelState.IsValid)
            {
                var res = _auth.Login(adminlogin);
                if (res)
                    return RedirectToPage("/Admin/Index");
            }
            return Page();
        }
    }
}
