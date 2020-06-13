using BoilerPlate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerPlate.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TestTable> TestTables { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        void RollbackTransaction();
    }
}
