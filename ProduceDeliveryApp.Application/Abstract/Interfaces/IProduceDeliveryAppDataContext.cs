using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProduceDeliveryApp.Domain;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Application.Abstract.Interfaces
{
    public interface IProduceDeliveryAppDataContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }

        Task SaveChangesAsync(CancellationToken token);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken token);
        Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken);
    }
}
