using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using TechnicalTest.Domain;
using TechnicalTest.Domain.Interfaces;

namespace TechnicalTest.App
{
    public class WordLadder
    {
        private readonly ILogger _logger;
        private readonly IArgumentValidator _argumentValidator;
        private readonly IWordLadderService _wordLadderService;
        private readonly IFileService _fileService;
        public WordLadder(ILogger<WordLadder> logger, IArgumentValidator argumentValidator, IWordLadderService wordLadderService, IFileService fileService)
        {
            _logger = logger;
            _argumentValidator = argumentValidator;
            _wordLadderService = wordLadderService;
            _fileService = fileService;
        }
        internal async Task Start(string[] args)
        {
            _logger.LogInformation($"Application Starting");
            _argumentValidator.ValidateArguments(args);

            var words = await _fileService.GetFileContentsAsync(args[0]);

            var StartWord = args[1].ToLowerInvariant();
            var EndWord = args[2].ToLowerInvariant();

            var validWords = _wordLadderService.FilterValidWords(words);
            if (!validWords.Contains(StartWord))
            {
                throw new ArgumentException("StartWord not in validWords");
            }

            if (!validWords.Contains(EndWord))
            {
                throw new ArgumentException("EndWord not in validWords");
            }

            
            Console.ReadLine();
        }
      
        internal void HandleGlobalError(Exception ex)
        {
            _logger.LogError($"An error occurred: {ex.Message}");
        }

    }
}
