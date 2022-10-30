using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace BookSabz.Presentation.WebRazor.Helpers
{

    // this class changed cooming soon...
    public class AuthAdmin
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private Guid Key;

        public AuthAdmin(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Login(AdminLoginModel command)
        {
            if (command.UserName == "aqamiti" && command.Password == "hoya123")
            {
                Key = Guid.NewGuid();
                var cookieoption = new CookieOptions
                {
                    Expires = DateTime.Now.AddHours(1)
                };

                _httpContextAccessor.HttpContext.Response.Cookies.Append("key", Key.ToString(), cookieoption);

                return true;
            }
            return false;
        }


        public bool CheckLogin()
        {
            var key = _httpContextAccessor.HttpContext.Request.Cookies["key"];

            if (!string.IsNullOrWhiteSpace(key))
            {
                if (Check_Key(key))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        private bool Check_Key(string key)
        {
            if (key == Key.ToString())
                return true;
            else
                return false;
        }
    }



    public class AdminLoginModel
    {
        [DisplayName("نام کاربری")]
        public string UserName { get; set; }

        [DisplayName("رمز عبور")]
        public string Password { get; set; }
    }

}
