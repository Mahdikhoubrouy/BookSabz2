using BookSabz.Core.Domain;
using BookSabz.Domain.BookAgg;
using BookSabz.Domain.BookCategoryAgg.Services;

namespace BookSabz.Domain.BookCategoryAgg
{
    public class BookCategory : DomainBase<int>
    {
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Book> Books { get; set; }

        protected BookCategory()
        {

        }

        public BookCategory(string name, IBookCategoryValidatorService _bookCategoryValidatorService)
        {

            _bookCategoryValidatorService.CheckThatThisRecordAlreadyExists(name);

            Name = name;
            IsDeleted = false;
            Books = new List<Book>();
        }


        public void Rename(string name)
        {
            Name = name;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void UnDelete()
        {
            IsDeleted = false;
        }
    }
}
