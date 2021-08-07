using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Domain.Interfaces;

namespace TechnicalTest.Domain.Services
{
    public class FileService : IFileService
    {

        private readonly ILogger<FileService> _logger;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public async Task<string[]> GetFileContentsAsync(string path)
        {
            _logger.LogInformation($"Loading file contents from {path}");
            return await File.ReadAllLinesAsync(path);
        }

        public async Task WriteResutsToFile(List<string> wordLadder, string filePath)
        {
            _logger.LogInformation($"Writing results to {filePath}");
            await File.WriteAllLinesAsync(filePath, wordLadder);
        }
    }
}
