using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Domain.Interfaces;

namespace TechnicalTest.Domain.Strategies
{
    public class FileOutputStrategy : OutputStrategy
    {

        private readonly ILogger<FileOutputStrategy> _logger;
        private readonly IFileService _fileService;
        private readonly ApplicationParameters _settings;

        public FileOutputStrategy(ILogger<FileOutputStrategy> logger, IOptions<ApplicationParameters> settings, IFileService fileService)
        {
            _logger = logger;
            _settings = settings.Value;
            _fileService = fileService;
        }

        public override async Task OutputData(List<string> wordLadder)
        {
            _logger.LogInformation($"Writing results to {_settings.OutputFile}");
            await _fileService.WriteResutsToFile(wordLadder, _settings.OutputFile);
        }
    }
}
