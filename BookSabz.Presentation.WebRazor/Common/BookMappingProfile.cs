using AutoMapper;
using BookSabz.Application.Contracts.Book.Models;
using TagHelpers.TagHelperModel;

namespace BookSabz.Presentation.WebRazor.Common
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<BookListViewModel, ViewBookTagHelperModel>().ReverseMap();
        }

    }
}
