using System.ComponentModel;

namespace BookSabz.Presentation.WebRazor.PresentationModel
{
	public class CreateBookCategoryPresentationModel
	{
        [DisplayName("نام کتگوری")]
        public string CategoryName { get; set; }
    }
}
