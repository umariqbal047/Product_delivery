using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Application.Abstract.Interfaces
{
    public interface ITransactionManager
    {
        Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task<ITransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default);
    }
}
