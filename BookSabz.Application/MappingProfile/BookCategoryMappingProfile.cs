using AutoMapper;
using BookSabz.Application.Contracts.BookCategory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSabz.Domain.BookCategoryAgg;

namespace BookSabz.Application.MappingProfile
{
	public class BookCategoryMappingProfile : Profile
	{
		public BookCategoryMappingProfile()
		{
			CreateMap<BookCategory, BookCategoryViewModel>().ForMember(x=>x.CreationDate,z=>z.MapFrom(a=>a.CreationDate.ToString()));
			CreateMap<BookCategory, RenameBookCategory>();
		}
	}
}
