using BookSabz.Application.Contracts.Book.Models;
using TagHelpers.TagHelperModel;

namespace BookSabz.Presentation.Web.Helpers
{
    public class GetBook
    {
        public static List<ViewBookTagHelperModel> GetBookListExecutor(Func<List<BookListViewModel>> func)
        {
            var invoke = func.Invoke();

            return invoke.Select(x => new ViewBookTagHelperModel
            {
                Author = x.Author,
                ImagePath = x.ImagePath,
                Id = x.Id,
                Name = x.Name
            }).ToList(); ;

        }


        public static List<ViewBookTagHelperModel> GetBookListExecutorWithParameter<TParameter>(Func<TParameter, List<BookListViewModel>> func, TParameter Parameter)
        {
            var invoke = func.Invoke(Parameter);

            return invoke.Select(x => new ViewBookTagHelperModel
            {
                Author = x.Author,
                ImagePath = x.ImagePath,
                Id = x.Id,
                Name = x.Name
            }).ToList(); ;

        }

    }
}
