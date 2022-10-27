using BookSabz.Application.Contracts.Search;
using BookSabz.Domain.SearchAgg.Repository;

namespace BookSabz.Application
{
	public class SearchApplication : ISearchApplication
	{
		private readonly ISearchRepository _searchRepository;

		public SearchApplication(ISearchRepository searchRepository)
		{
			_searchRepository = searchRepository;
		}

		public List<SearchViewModel> Search(SearchModel command)
		{
			return _searchRepository.SearchAnyValue(command.Value);
		}
	}
}
