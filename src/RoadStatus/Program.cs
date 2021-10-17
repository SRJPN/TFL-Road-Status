using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoadStatus.Http;
using RoadStatus.HttpClients;
using RoadStatus.HttpClients.Interfaces;

namespace RoadStatus
{
    class Program
    {
        private static IConfigurationRoot config;

        public static async Task Main(string[] args)
        {
            InitConfig();
            ServiceProvider serviceProvider = RegisterServices();

            var httpResponseMessage = await serviceProvider.GetService<IRoadServiceHttpClient>().GetRoadStatusAsync("A2");

            Console.WriteLine(httpResponseMessage.StatusCode);
            Console.WriteLine(await httpResponseMessage.Content.ReadAsStringAsync());
        }

        private static void InitConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            config = builder.Build();
        }

        private static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IAppSettings>(_ => config.Get<AppSettings>());
            services.AddTransient<IRoadServiceHttpClient, RoadServiceHttpClient>();
            services.AddTransient<IHttpClient, HttpClientWrapper>();
            services.AddTransient<HttpClient>(_ => new HttpClient());
            return services.BuildServiceProvider();
        }
    }
}
