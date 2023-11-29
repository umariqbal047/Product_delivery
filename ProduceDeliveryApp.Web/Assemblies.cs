using System.Reflection;

namespace ProduceDeliveryApp.Web
{
    public class Assemblies
    {
        public static Assembly[] Get()
        {
            return new[]
            {
                typeof(IMarker).Assembly,
                typeof(Application.IMarker).Assembly,
                //typeof(Domain.IMarker).Assembly,
                typeof(Persistence.IMarker).Assembly,
                typeof(DataRead.IMarker).Assembly,
                //typeof(Infrastructure.IMarker).Assembly
            };
        }
    }
}
