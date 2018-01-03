using Inators.Azure.WebJobs.Extensions.Inject;
using Microsoft.Extensions.DependencyInjection;

namespace Inators.FunctionsInjectSample
{
    public class RegisterServices : IRegisterServices
    {
        public void PopulateServiceCollection(IServiceCollection services)
        {
            services.AddSingleton<IConcatService, ConcatService>();
        }

    }
}