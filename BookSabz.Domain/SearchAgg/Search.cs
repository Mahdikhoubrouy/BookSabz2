using BookSabz.Domain.SearchAgg.SearchException;
using System.Text.RegularExpressions;

namespace BookSabz.Domain.SearchAgg
{
	public class Search
	{
		public string Value { get; set; }

		public Search(string value)
		{
			CheckValidData(value);

			Value = value;
		}



        public void CheckValidData(string value)
        {
            if (Regex.IsMatch(value, @"([!@#$%^&*()_+=/*?-])+"))
                throw new SearchWrongPatternText("Please Don't Use (@#$%^&*()_+=/*?-) symbols !");
        }

    }

}
