using Microsoft.EntityFrameworkCore.Storage;

namespace BookSabz.Core.Infrastructure
{
    public interface IDbUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void Rollback();
        void SaveChange();
    }
}
