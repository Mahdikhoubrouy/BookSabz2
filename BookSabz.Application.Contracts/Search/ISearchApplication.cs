using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.Search
{
	public interface ISearchApplication
	{
		List<SearchViewModel> Search(SearchModel command);
	}
}
