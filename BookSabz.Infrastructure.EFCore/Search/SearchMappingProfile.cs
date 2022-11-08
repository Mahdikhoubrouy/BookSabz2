using AutoMapper;
using BookSabz.Application.Contracts.Search;
using BookSabz.Domain.BookAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.Search
{
    internal class SearchMappingProfile : Profile
    {
        public SearchMappingProfile()
        {
            CreateMap<Book, SearchViewModel>();
        }
    }
}
