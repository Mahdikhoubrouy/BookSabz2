using BookSabz.Core.Domain;
using System.Linq.Expressions;

namespace BookSabz.Core.Infrastructure.ReadRepository
{
    public interface IReadRepository<in Tkey, T> where T : DomainBase<Tkey>
    {
        Task<T> GetAsync(Tkey id);
        Task<List<T>> GetAllAsNoTrackingAsync();
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
