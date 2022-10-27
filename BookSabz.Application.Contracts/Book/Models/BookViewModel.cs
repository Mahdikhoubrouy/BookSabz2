using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.Book.Models
{
    public class BookViewModel : BookBase
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
    }
}
