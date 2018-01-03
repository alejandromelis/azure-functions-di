using Microsoft.Extensions.DependencyInjection;

namespace Inators.Azure.WebJobs.Extensions.Inject
{
    public interface IRegisterServices
    {
        void PopulateServiceCollection(IServiceCollection services);
    }


}