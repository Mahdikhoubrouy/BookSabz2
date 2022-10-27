namespace BookSabz.Domain.BookCategoryAgg.BookCategoryException
{
    public class BookCategoryDuplicatedRecordException : Exception
    {
        public BookCategoryDuplicatedRecordException()
        {
        }

        public BookCategoryDuplicatedRecordException(string? message) : base(message)
        {
        }
    }
}
