using BookSabz.Domain.BookAgg;
using BookSabz.Domain.BookCategoryAgg;
using BookSabz.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookSabz.Infrastructure.EFCore
{
    public class BookSabzContext : DbContext
    {
        public BookSabzContext(DbContextOptions<BookSabzContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(BookMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
