using System;

namespace ProduceDeliveryApp.Application.Abstract.Interfaces
{
    public interface ITransaction : IDisposable
    {
        Guid Id { get; }
        void Commit();
        void Rollback();
    }
}
