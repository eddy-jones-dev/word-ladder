using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TechnicalTest.Domain;
using TechnicalTest.Domain.Interfaces;
using TechnicalTest.Domain.Services;
using TechnicalTest.Domain.Strategies;

namespace TechnicalTest.App
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services,args);
            
            var serviceProvider = services.BuildServiceProvider();

            var argumentValidator = serviceProvider.GetService<IArgumentValidator>();
            argumentValidator.ValidateArguments(args);
   
            var app = serviceProvider.GetService<WordLadder>();

            try
            {
                await app.Start(args);
            }
            catch (Exception ex)
            {
                app.HandleGlobalError(ex);
                throw ex;
            }
            
            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection services,string[] args)
        {
            services.AddOptions<ApplicationParameters>().Configure(opts =>
            {
                opts.DictionaryFile = args[0];
                opts.StartWord = args[1].ToLowerInvariant();
                opts.EndWord = args[2].ToLowerInvariant();
                opts.OutputFile = args[3];
            });

            services.AddLogging(configure => configure.AddConsole())
            .AddTransient<IArgumentValidator,ArgumentValidator>()
            .AddTransient<IFileService,FileService>()
            .AddTransient<IWordLadderService,WordLadderService>()   
            .AddTransient<OutputStrategy,FileOutputStrategy>()
            .AddTransient<OutputStrategy,ConsoleOutputStrategy>()
            .AddTransient<WordLadder>();
        }
    }
}
