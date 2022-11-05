using BookSabz.Domain.BookCategoryAgg.BookCategoryException;
using BookSabz.Domain.BookCategoryAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Domain.BookCategoryAgg.Services
{
    public class BookCategoryValidatorService : IBookCategoryValidatorService
    {
        private readonly IReadBookCategoryRepository _readBookCategoryRepository;

        public BookCategoryValidatorService(IReadBookCategoryRepository readBookCategoryRepository)
        {
            _readBookCategoryRepository = readBookCategoryRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string CategoryName)
        {

            var res = _readBookCategoryRepository.Exists(x => x.Name == CategoryName);

            if (res)
            {
                throw new BookCategoryDuplicatedRecordException("error");
            }
        }
    }
}
