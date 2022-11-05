using BookSabz.Application.Contracts.Search;
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

        public SearchRepository(BookSabzContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public List<SearchViewModel> SearchAnyValue(Domain.SearchAgg.Search command)
        {
            return _dbContext.Books
                    .AsNoTracking()
                    .Include(x => x.BookCategory)
                    .Where(x => x.Name.Contains(command.Value) || x.BookCategory.Name.Contains(command.Value) || x.Author.Contains(command.Value))
                    .Select(x => new SearchViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ImagePath = x.ImagePath
                    }).ToList();
        }
    }
}
