using BookSabz.Application.Contracts.BookCategory.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.BookCategory.BookCategoryValidation
{
	public class RenameBookCategoryValidation : AbstractValidator<RenameBookCategory>
	{
		public RenameBookCategoryValidation()
		{
			RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
		}
	}
}
