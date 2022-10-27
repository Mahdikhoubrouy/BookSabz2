using BookSabz.Application.Contracts.Book.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.Book.BookValidation
{
    public class BookValidator : AbstractValidator<BookBase>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(2, 25).WithMessage(MessageCeator("نام")).WithName("نام");
            RuleFor(x => x.Author).NotNull().NotEmpty().Length(2, 25).WithMessage(MessageCeator("نام نویسنده"));
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage(MessageCeator("توضیحات"));
            RuleFor(x => x.PublishYear).NotNull().NotEmpty().Length(5,10).WithMessage(MessageCeator("سال انتشار"));
            RuleFor(x => x.ImagePath).NotNull().NotEmpty().WithMessage(MessageCeator("عکس کتاب"));
            RuleFor(x => x.FilePath).NotNull().NotEmpty().WithMessage(MessageCeator("فایل کتاب"));
        }

        private string MessageCeator(string name)
        {
            return $"لطفا مقدار {name} را صحیح وارد کنید";
        }
    }
}
