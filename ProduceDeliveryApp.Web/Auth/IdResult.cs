using Microsoft.AspNetCore.Identity;
using ProduceDeliveryApp.Application.Abstract.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProduceDeliveryApp.Web.Auth
{
    public class IdResult : IIdentityResult
    {
        private readonly IdentityResult _result;

        public IdResult(IdentityResult result)
        {
            _result = result;
        }

        public bool Succeeded => _result.Succeeded;
        public IEnumerable<(string Code, string Description)> Errors => _result.Errors.Select(x => (x.Code, x.Description));
    }

}
