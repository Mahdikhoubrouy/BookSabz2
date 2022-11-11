using BookSabz.Core.Domain;
using BookSabz.Domain.BookAgg.Services;
using BookSabz.Domain.BookCategoryAgg;

namespace BookSabz.Domain.BookAgg
{
    public class Book : DomainBase<long>
    {
        public string Name { get; private set; }
        public string ImagePath { get; private set; }
        public string Author { get; private set; }
        public string PublishYear { get; private set; }
        public string FilePath { get; private set; }
        public int BookCategoryId { get; private set; }
        public string Description { get; private set; }
        public long DownloadCount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsVisible { get; set; }

        public BookCategory BookCategory { get; private set; }



        protected Book()
        {

        }

        public Book(string name, string image, string author, string publishYear, string filePath, string description, int bookCategoryId, IBookValidatorService _ValidatorService)
        {

            _ValidatorService.CheckBookCategoryIdAlreadyExists(bookCategoryId);

            Name = name;
            ImagePath = image;
            Author = author;
            PublishYear = publishYear;
            FilePath = filePath;
            Description = description;
            IsDeleted = false;
            IsVisible = true;
            BookCategoryId = bookCategoryId;


        }


        public void Edit(string name, string image, string author, string publishYear, string filePath, string description, int bookcategoryid)
        {
            Name = name;
            ImagePath = image;
            Author = author;
            PublishYear = publishYear;
            FilePath = filePath;
            Description = description;
            BookCategoryId = bookcategoryid;
        }


        public void Delete()
        {
            IsDeleted = true;
        }

        public void UnDelete()
        {
            IsDeleted = false;
        }

        public void Visible()
        {
            IsVisible = true;
        }

        public void UnVisible()
        {
            IsVisible = false;
        }



    }
}
