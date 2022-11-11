using AutoMapper;
using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Application.Contracts.BookApp;
using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Application.Contracts.BookCategory.Models;
using BookSabz.Presentation.WebRazor.AdminModel;
using BookSabz.Presentation.WebRazor.PresentationModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookSabz.Presentation.WebRazor.Pages.Admin
{
	[Authorize(Roles = "admin")]
	public class EditBookModel : PageModel
	{
		public EditBookPresentationModel Book { get; set; }

		public List<SelectListItem> Categories { get; set; }

		private readonly IBookCategoryApplication _bookCategoryApplication;
		private readonly IBookApplication _bookApplication;
		private readonly IMapper _mapper;

		public EditBookModel(IBookApplication bookApplication, IBookCategoryApplication bookCategoryApplication, IMapper mapper)
		{
			_bookApplication = bookApplication;
			_bookCategoryApplication = bookCategoryApplication;
			_mapper = mapper;
			Categories = new List<SelectListItem>();
		}

		[TempData]
		public string ErrorMessage { get; set; }


		public async Task<IActionResult> OnGet(long id)
		{
			var book = _bookApplication.GetById(id);
			var category = await _bookCategoryApplication.GetByNameAsync(book.CategoryName);
			var AllCategory = await _bookCategoryApplication.GetListAsync();

			if (book == null)
				return NotFound();


			AllCategory.ForEach(c =>
			{
				if (category.Id == c.Id)
				{
					Categories.Add(new SelectListItem
					{
						Text = c.Name,
						Value = c.Id.ToString(),
						Selected = true,
					});
				}
				else
				{
					Categories.Add(new SelectListItem
					{
						Text = c.Name,
						Value = c.Id.ToString()
					});
				}
			});

			Book = _mapper.Map<BookViewModel, EditBookPresentationModel>(book);
			Book.CategoryId = category.Id;



			return Page();
		}


		public IActionResult OnPostEdit(EditBookPresentationModel book)
		{
			var Orgbook = _bookApplication.GetById(book.Id);

			if (Orgbook == null) return NotFound();



			var editedBook = new EditBook()
			{
				Author = book.Author,
				BookCategoryId = book.CategoryId,
				Description = book.Description,
				FilePath = Orgbook.FilePath,
				Id = book.Id,
				ImagePath = Orgbook.ImagePath,
				Name = book.Name,
				PublishYear = book.PublishYear,
			};

			_bookApplication.Edit(editedBook);

			return RedirectToPage("/Admin/Index");


		}

	}
}
