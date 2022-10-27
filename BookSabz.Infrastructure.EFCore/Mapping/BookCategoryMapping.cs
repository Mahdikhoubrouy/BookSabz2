using BookSabz.Domain.BookCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.Mapping
{
    public class BookCategoryMapping : IEntityTypeConfiguration<BookCategory>
    {
        // TODO: set configuration ...
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.HasMany(x => x.Books).WithOne(x => x.BookCategory).HasForeignKey(x => x.BookCategoryId);
        }
    }
}
