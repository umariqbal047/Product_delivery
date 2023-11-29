using System.Collections.Generic;

namespace ProduceDeliveryApp.Application.Abstract.Interfaces
{
    public interface IIdentityResult
    {
        bool Succeeded { get; }
        IEnumerable<(string Code, string Description)> Errors { get; }
    }
}
