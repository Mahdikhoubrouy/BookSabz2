using AutoMapper;
using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Application.Contracts.BookApp;
using BookSabz.Application.Contracts.BookCategory;
using BookSabz.Domain.BookAgg;
using BookSabz.Infrastructure.EFCore;
using BookSabz.Presentation.WebRazor.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using TagHelpers.TagHelperModel;

namespace BookSabz.Presentation.WebRazor.Pages
{
    public class IndexModel : PageModel
    {
        // TODO : this section added book list with options => (Edit , Delete)
        public List<ViewBookTagHelperModel> PopularBook { get; set; }

        public List<ViewBookTagHelperModel> NewBook { get; set; }


        private readonly IBookApplication _book;
        private readonly IMapper _mapper;

        private readonly UserManager<IdentityUser> _user;

        private readonly RoleManager<IdentityRole> _role;

        public IndexModel(IBookApplication book, IMapper mapper, UserManager<IdentityUser> user, RoleManager<IdentityRole> role)
        {
            _book = book;
            _mapper = mapper;
            _user = user;
            _role = role;
        }


        public async void OnGet()
        {

            PopularBook = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetLisProposede());

            NewBook = _mapper.Map<List<BookListViewModel>, List<ViewBookTagHelperModel>>(_book.GetListByDateTime(DateTime.Now.AddDays(-7)));


            //await _user.SetEmailAsync(_user.FindByNameAsync("miticyber").GetAwaiter().GetResult(), "Test1234!");
            //await _user.CreateAsync(new IdentityUser("miticyber"));
            //await _role.CreateAsync(new IdentityRole("admin"));

            //await _user.AddToRoleAsync(_user.FindByNameAsync("winaj31786@lidely.com").GetAwaiter().GetResult(), "admin");

        }
    }
}