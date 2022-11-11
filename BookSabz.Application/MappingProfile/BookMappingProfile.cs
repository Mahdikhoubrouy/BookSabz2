using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSabz.Domain.BookAgg;
using BookSabz.Application.Contracts.Book.Models;

namespace BookSabz.Application.Contracts.Management.BookManagement
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<BookSabz.Domain.BookAgg.Book, BookManagementModel>().ForMember(x => x.CategoryName, z => z.MapFrom(t => t.BookCategory.Name));
        }
    }
}
