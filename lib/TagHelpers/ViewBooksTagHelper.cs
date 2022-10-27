using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.TagHelperModel;

namespace BookSabz.TagHelerViewBook
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    public class ViewBooksTagHelper : TagHelper
    {
		public List<ViewBookTagHelperModel> BookList { get; set; }

		public string AspPageName { get; set; }

		public string SectionName { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = "";
            string result = "";

            output.TagName = "section";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "featured");
            output.Attributes.Add("id", "featured");
            
            foreach (var book in BookList)
			{
                string route = $"/{AspPageName}/{book.Id}";
                content += "<div class=\"swiper-slide box\"> <div class=\"icons\">";
                content += "<a href=\"#\" class=\"fas fa-heart\"></a>";
                content += $"<a href=\"{route}\" class=\"fas fa-eye\"></a></div> <div class=\"image\">";
                content += $"<img src=\"/Books/images/{book.ImagePath}\" alt=\"\"> </div> <div class=\"content\">";
                content += $"<h3>{book.Name}</h3>";
                content += $"<div class=\"price\">{book.Author}</div>";
                content += $"<a href=\"{route}\"  class=\"btn\">ادامه و دانلود ...</a></div></div>";

            }

            result += $"<h1 class=\"heading\"> <span>{SectionName}</span> </h1>";
            result += "<div class=\"swiper featured-slider\"> <div class=\"swiper-wrapper\">";
            result += content;
            result += "</div><div class=\"swiper-button-next\"></div><div class=\"swiper-button-prev\"></div></div>";


            output.Content.AppendHtml(result);
        }
    }
}
