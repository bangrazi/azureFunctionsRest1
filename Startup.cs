using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(azureFunctionsRest1.Startup))]

namespace azureFunctionsRest1 {
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder) {
            builder.Services.AddSingleton<IService, Service>();
        }
    }
}