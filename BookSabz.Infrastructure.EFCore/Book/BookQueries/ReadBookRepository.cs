using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Core.Infrastructure.ReadRepository;
using BookSabz.Domain.BookAgg;
using BookSabz.Domain.BookAgg.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookSabz.Infrastructure.EFCore.BookRep.BookQueries
{
	public class ReadBookRepository : ReadRepositoryBase<long, Book>, IReadBookRepository
	{
		private readonly BookSabzContext _dbContext;

		public ReadBookRepository(BookSabzContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public List<BookListViewModel> GetListByCategoryName(string categoryName)
		{

			return _dbContext.Books.Include(x => x.BookCategory)
				.AsNoTracking()
				.Where(x => x.BookCategory.Name == categoryName)
				.Select(s => new BookListViewModel
				{
					Author = s.Author,
					Id = s.Id,
					ImagePath = s.ImagePath,
					Name = s.Name,
				})
				.ToList();
		}

		public BookViewModel GetByExpression(Expression<Func<Book, bool>> expression)
		{
			return _dbContext.Books.Include(x => x.BookCategory)
				.Where(expression).Select(x => new BookViewModel
				{
					Author = x.Author,
					Name = x.Name,
					ImagePath = x.ImagePath,
					Id = x.Id,
					CategoryName = x.BookCategory.Name,
					Description = x.Description,
					FilePath = x.FilePath,
					PublishYear = x.PublishYear
				}).FirstOrDefault()!;

		}

		public BookViewModel GetById(long id)
		{
			return _dbContext.Books.Include(x => x.BookCategory).Where(x => x.Id == id)
				 .Select(x => new BookViewModel
				 {
					 Author = x.Author,
					 Name = x.Name,
					 ImagePath = x.ImagePath,
					 Id = x.Id,
					 CategoryName = x.BookCategory.Name,
					 Description = x.Description,
					 FilePath = x.FilePath,
					 PublishYear = x.PublishYear
				 }).SingleOrDefault()!;

		}

		public List<BookListViewModel> GetListByExpression(Expression<Func<Book, bool>> expression)
		{
			return _dbContext.Books.Include(x => x.BookCategory).AsNoTracking()
				.Where(expression)
				.Select(s => new BookListViewModel
				{
					Author = s.Author,
					Id = s.Id,
					ImagePath = s.ImagePath,
					Name = s.Name,
				}).ToList();

		}

		public List<Book> GetAllAsNoTracking()
		{
			return _dbContext.Books
				.Include(x => x.BookCategory)
				.AsNoTracking()
				.ToList();
		}
	}
}
