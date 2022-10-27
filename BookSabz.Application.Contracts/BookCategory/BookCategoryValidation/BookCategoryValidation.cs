using BookSabz.Application.Contracts.BookCategory.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.BookCategory.BookCategoryValidation
{
    public class BookCategoryValidator : AbstractValidator<BookCategoryBase>
    {
        public BookCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(2, 25).WithMessage("مقدار وارد شده صحیح نیست !");

        }
    }
}
