using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.TagHelperModel;

namespace BookSabz.TagHelperNewBook
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    public class NewBookTagHelper : TagHelper
    {
        public List<ViewBookTagHelperModel> NewBookList { get; set; }
        public string SectionName { get; set; }
        public string AspPageName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int ComlunNumber = NewBookList.Count / 2;
            List<ViewBookTagHelperModel> Column1 = NewBookList.TakeLast(ComlunNumber).ToList();
            List<ViewBookTagHelperModel> Column2 = NewBookList.SkipLast(ComlunNumber).Take(ComlunNumber).ToList();
            string result = "";
            output.TagName = "section";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "arrivals");
            output.Attributes.Add("id", "arrivals");

            result += "<h1 class=\"heading\"> <span>کتابهای جدید</span> </h1>";
            result += "<div class=\"swiper arrivals-slider\"><div class=\"swiper-wrapper\">";
            result += CreateBoxSlider(Column1,AspPageName);
            result += "</div></div>";
            result += "<div class=\"swiper arrivals-slider\"><div class=\"swiper-wrapper\">";
            result += CreateBoxSlider(Column2, AspPageName);
            result += "</div></div>";


            output.Content.AppendHtml(result);
        }

        private static string CreateBoxSlider(List<ViewBookTagHelperModel> BookList,string PageName)
        {
            string content = "";
            foreach (var book in BookList)
            {
                string route = $"/{PageName}/{book.Id}";
                content += $"<a href= \"{route}\" class=\"swiper-slide box\">";
                content += $"<div class=\"image\"><img src=\"/Books/images/{book.ImagePath}\"alt =\"\"></div>";
                content += $"<div class=\"content\"><h3>{book.Name}</h3>";
                content += $"<div class=\"price\">{book.Author}</div></div></a>";
            }

            return content;
        }
    }
}
