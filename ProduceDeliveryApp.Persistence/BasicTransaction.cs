using Microsoft.EntityFrameworkCore.Storage;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using System;

namespace ProduceDeliveryApp.Persistence
{
    public class BasicTransaction : ITransaction
    {
        private readonly IDbContextTransaction _transaction;

        public BasicTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public Guid Id => _transaction.TransactionId;

        public void Commit() => _transaction.Commit();
        public void Rollback() => _transaction.Rollback();
        public void Dispose() => _transaction.Dispose();
    }

}
