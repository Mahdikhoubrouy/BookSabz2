using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.Book.Models
{
    public class BookBase
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public string PublishYear { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
    }
}
