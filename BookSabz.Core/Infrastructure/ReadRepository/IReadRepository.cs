using BookSabz.Core.Domain;
using System.Linq.Expressions;

namespace BookSabz.Core.Infrastructure.ReadRepository
{
    public interface IReadRepository<in Tkey, T> where T : DomainBase<Tkey>
    {
        Task<T> GetAsync(Tkey id);
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
