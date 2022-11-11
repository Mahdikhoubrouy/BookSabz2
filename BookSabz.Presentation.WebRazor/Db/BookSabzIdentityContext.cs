using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookSabz.Presentation.WebRazor.Db
{
    public class BookSabzIdentityContext : IdentityDbContext
    {
        public BookSabzIdentityContext(DbContextOptions<BookSabzIdentityContext> options) : base(options)
        {
        }


    }
}
