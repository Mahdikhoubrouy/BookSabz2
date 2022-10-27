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

        public async void CheckThatThisRecordAlreadyExists(string CategoryName)
        {
            if (await _readBookCategoryRepository.ExistsAsync(x => x.Name == CategoryName))
                throw new BookCategoryDuplicatedRecordException();
        }
    }
}
