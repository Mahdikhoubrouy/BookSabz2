using AutoMapper;
using BookSabz.Application.Contracts.Search;
using BookSabz.Domain.BookAgg;
using BookSabz.Domain.SearchAgg.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Infrastructure.EFCore.Search
{
    public class SearchRepository : ISearchRepository
    {
        private readonly BookSabzContext _dbContext;

        private readonly IMapper _mapper;
        public SearchRepository(BookSabzContext dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }

        public List<SearchViewModel> SearchAnyValue(Domain.SearchAgg.Search command)
        {
            return _dbContext.Books
                    .AsNoTracking()
                    .Include(x => x.BookCategory)
                    .Where(x => x.Name.Contains(command.Value) || x.BookCategory.Name.Contains(command.Value) || x.Author.Contains(command.Value))
                    .Select(x => _mapper.Map<Book, SearchViewModel>(x)).ToList();
        }
    }
}
