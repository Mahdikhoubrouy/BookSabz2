using BookSabz.Domain.BookAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(500);
            builder.Property(x=>x.Author).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PublishYear).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Description).IsRequired();;
            builder.HasOne(x => x.BookCategory).WithMany(x => x.Books).HasForeignKey(x => x.BookCategoryId);
        }
    }
}
