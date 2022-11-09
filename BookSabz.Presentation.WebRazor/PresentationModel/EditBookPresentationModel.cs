using System.ComponentModel;

namespace BookSabz.Presentation.WebRazor.PresentationModel
{
	public class EditBookPresentationModel
	{
		[DisplayName("نام")]
		public string Name { get; set; }
		[DisplayName("نویسنده")]
		public string Author { get; set; }
		[DisplayName("گروه")]
		public int CategoryId { get; set; }
		[DisplayName("سال انتشار")]
		public string PublishYear { get; set; }
		[DisplayName("توضیحات")]
		public string Description { get; set; }

		public int Id { get; set; }

	}
}
