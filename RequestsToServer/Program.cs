/*
                                                   Задача (A-Level Sample)

● Виконати всі запити https://reqres.in/ і обробити всі відповіді з сервера.
● Запити виконати асихронно в паралелі і діждатися їх виконання.

 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RequestsToServer.Config;
using RequestsToServer.Helpers;
using RequestsToServer.Services;
using RequestsToServer.Services.Interfaces;

namespace RequestsToServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(Constants.JsonConfig)
                .Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            var provider = serviceCollection.BuildServiceProvider();

            var app = provider.GetService<App>();
            await app!.StartAsync();

            await Task.Delay(300); // To ensure that all logs were printed on console before this message pop up
            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<APIConfig>().Bind(configuration.GetSection(Constants.KeySection));
            serviceCollection
                .AddLogging(configure => configure.AddConsole())
                .AddHttpClient()
                .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IAuthenticationService, AuthenticationService>()
                .AddTransient<IResourceService, ResourceService>()
                .AddTransient<App>();
        }
    }
}