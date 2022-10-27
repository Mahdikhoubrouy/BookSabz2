using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Application.Contracts.ExceptionHandler
{
    public sealed class ResultHandler<TModelSuccess>
    {
        public class Success
        {
            public TModelSuccess Result { get; set; }
        }

        public class Error
        {
            public string Message { get; set; }
        }
    }
}
