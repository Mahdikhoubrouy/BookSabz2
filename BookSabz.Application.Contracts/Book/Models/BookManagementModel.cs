using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.Book.Models
{
    public class BookManagementModel
    {
        public long Id { get; set; }
        public string Name { get; private set; }
        public string ImagePath { get; private set; }
        public string Author { get; private set; }
        public string PublishYear { get; private set; }
        public string CategoryName { get; private set; }
        public bool IsDeleted { get; set; }
        public bool IsVisible { get; set; }
    }
}
