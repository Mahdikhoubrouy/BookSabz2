using BookSabz.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSabz.Core.Infrastructure.WriteRepository
{
    public interface IWriteRepository<T, TKey> where T : DomainBase<TKey>
    {
        void Create(T entity);
    }
}
