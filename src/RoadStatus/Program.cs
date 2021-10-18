using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoadStatus.Http;
using RoadStatus.Http.Interfaces;
using RoadStatus.Models;
using RoadStatus.Services;

namespace RoadStatus
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        private static IConfigurationRoot config;

        public static async Task<int> Main(string[] args)
        {
            InitConfig();
            ServiceProvider serviceProvider = RegisterServices();

            var response = await serviceProvider.GetService<IRoadStatusService>().GetRoadStatusAsync(args[0]);

            return PrintResponse(response);
        }

        private static int PrintResponse(IRoadStatusResponse response)
        {
            if (response is IErrorResponse)
            {
                Console.WriteLine(response.DisplayStatus());
                return 1;
            }
            Console.WriteLine(response.DisplayStatus());
            return 0;
        }

        private static void InitConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            config = builder.Build();
        }

        private static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IAppSettings>(_ => config.Get<AppSettings>());
            services.AddTransient<IRoadStatusHttpClient, RoadStatusHttpClient>();
            services.AddTransient<IHttpClient, HttpClientWrapper>();
            services.AddTransient<IRoadStatusService, RoadStatusService>();
            services.AddTransient<HttpClient>(_ => new HttpClient());
            return services.BuildServiceProvider();
        }
    }
}
