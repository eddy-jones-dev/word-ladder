using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Domain.Strategies
{
    public class FileOutputStrategy : OutputStrategy
    {

        private readonly ILogger<FileOutputStrategy> _logger;
        private readonly ApplicationParameters _settings;

        public FileOutputStrategy(ILogger<FileOutputStrategy> logger, IOptions<ApplicationParameters> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public override async Task OutputData(List<string> wordLadder)
        {
            _logger.LogInformation($"Writing results to {_settings.OutputFile}");
            await File.WriteAllLinesAsync(_settings.OutputFile, wordLadder);
        }
    }
}
