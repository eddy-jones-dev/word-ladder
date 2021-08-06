using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TechnicalTest.Domain;
using TechnicalTest.Domain.Interfaces;
using TechnicalTest.Domain.Services;

namespace TechnicalTest.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            WordLadder app = serviceProvider.GetService<WordLadder>();

            try
            {
                app.Start(args);
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
            .AddTransient<IWordLadderService,WordLadderService>()
            .AddTransient<WordLadder>();
        }
    }
}
