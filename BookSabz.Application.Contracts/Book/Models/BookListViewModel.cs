using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.Book.Models
{
    public class BookListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
    }
}
