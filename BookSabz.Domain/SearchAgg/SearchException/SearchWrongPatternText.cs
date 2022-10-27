using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Domain.SearchAgg.SearchException
{
	public class SearchWrongPatternText : Exception
	{
		public SearchWrongPatternText()
		{
		}

		public SearchWrongPatternText(string message) : base(message)
		{
		}
	}
}
