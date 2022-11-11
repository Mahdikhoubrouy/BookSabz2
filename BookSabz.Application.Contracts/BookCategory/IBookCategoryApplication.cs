using BookSabz.Application.Contracts.BookCategory.Models;

namespace BookSabz.Application.Contracts.BookCategory
{
    public interface IBookCategoryApplication
    {
        Task<List<BookCategoryViewModel>> GetListAsync();

        void Create(CreateBookCategory command);

        Task Rename(RenameBookCategory command);

        Task<RenameBookCategory> Get(int id);

        Task Delete(int id);

        Task UnDelete(int id);

        Task<BookCategoryViewModel> GetByNameAsync(string name);
    }
}
