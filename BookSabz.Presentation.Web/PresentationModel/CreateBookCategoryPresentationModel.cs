using System.ComponentModel;

namespace BookSabz.Presentation.Web.PresentationModel
{
	public class CreateBookCategoryPresentationModel
	{
        [DisplayName("نام کتگوری")]
        public string CategoryName { get; set; }
    }
}
