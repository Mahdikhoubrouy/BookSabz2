using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Domain.BookAgg.Services
{
    public interface IBookValidatorService
    {
        void CheckBookCategoryIdAlreadyExists(int categoryId);

    }
}
