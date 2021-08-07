using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TechnicalTest.Domain;
using TechnicalTest.Domain.Interfaces;
using TechnicalTest.Domain.Services;

namespace TechnicalTest.App
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            
            var serviceProvider = services.BuildServiceProvider();
            var app = serviceProvider.GetService<WordLadder>();

            try
            {
                await app.Start(args);
            }
            catch (Exception ex)
            {
                app.HandleGlobalError(ex);
            }
            
            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
            .AddTransient<IArgumentValidator,ArgumentValidator>()
            .AddTransient<IFileService,FileService>()
            .AddTransient<IWordLadderService,WordLadderService>()
            .AddTransient<WordLadder>();
        }
    }
}
