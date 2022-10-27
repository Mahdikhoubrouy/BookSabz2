using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Core.Domain
{
    public abstract class DomainBase<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }

        protected DomainBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
