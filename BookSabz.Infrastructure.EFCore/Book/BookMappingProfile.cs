using AutoMapper;
using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Domain.BookAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.BookMapper
{
    internal class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookListViewModel>();
            CreateMap<Book, BookViewModel>();
        }
    }
}
