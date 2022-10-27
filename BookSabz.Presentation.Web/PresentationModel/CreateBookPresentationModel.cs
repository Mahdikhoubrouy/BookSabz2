using System.ComponentModel;

namespace BookSabz.Presentation.Web.AdminModel
{
	public class CreateBookPresentationModel
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
        [DisplayName("عکس")]
        public IFormFile Image { get; set; }
        [DisplayName("فایل کتاب")]
        public IFormFile BookFile { get; set; }

    }

}
