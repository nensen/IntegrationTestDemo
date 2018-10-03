using Core.Mocks;
using Core.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Api.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Api.Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return base.CreateWebHostBuilder().UseEnvironment("test");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // Inject test dependecies to SUT
            builder.ConfigureServices(services =>
            {
                services.AddTransient<IFooRepository, FooRepositoryFake>();
            });
        }
    }
}