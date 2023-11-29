using ProduceDeliveryApp.Application.Abstract.Interfaces;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ProduceDeliveryApp.Persistence
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ProduceDeliveryAppDataContext _context;

        public TransactionManager(ProduceDeliveryAppDataContext context)
        {
            _context = context;
        }

        public async Task<ITransaction> BeginTransactionAsync(
            CancellationToken cancellationToken = default)
        {
            var transaction = await _context.BeginTransactionAsync(cancellationToken);
            return new BasicTransaction(transaction);
        }

        public async Task<ITransaction> BeginTransactionAsync(
            IsolationLevel isolationLevel,
            CancellationToken cancellationToken = default)
        {
            var transaction = await _context.BeginTransactionAsync(isolationLevel, cancellationToken);
            return new BasicTransaction(transaction);
        }
    }

}
