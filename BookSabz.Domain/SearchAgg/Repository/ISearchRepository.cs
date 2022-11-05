using BookSabz.Application.Contracts.Book.Models;
using BookSabz.Application.Contracts.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Domain.SearchAgg.Repository
{
	public interface ISearchRepository
	{
		List<SearchViewModel> SearchAnyValue(Search command);
	}
}
