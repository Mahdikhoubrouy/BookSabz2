using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Domain.BookCategoryAgg.Services
{
    public interface IBookCategoryValidatorService
    {
        void CheckThatThisRecordAlreadyExists(string CategoryName);
    }
}
