using BookSabz.Domain.BookAgg.BookException;
using BookSabz.Domain.BookCategoryAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Domain.BookAgg.Services
{
    public class BookValidatorService : IBookValidatorService
    {
        private readonly IReadBookCategoryRepository _readBookCategoryRepository;

        public BookValidatorService(IReadBookCategoryRepository readBookCategoryRepository)
        {
            _readBookCategoryRepository = readBookCategoryRepository;
        }

        public async void CheckBookCategoryIdAlreadyExists(int categoryId)
        {
            if (!await _readBookCategoryRepository.ExistsAsync(x => x.Id == categoryId))
                throw new CategoryNotFoundException();
        }
    }
}
