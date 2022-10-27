using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.BookCategory.Models
{
    public class BookCategoryViewModel : BookCategoryBase
    {
        public int Id { get; set; }

        public string CreationDate { get; set; }

        public bool IsDeleted { get; set; }


    }
}
