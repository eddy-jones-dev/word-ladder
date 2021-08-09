using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTest.Domain;
using TechnicalTest.Domain.Interfaces;
using TechnicalTest.Domain.Strategies;

namespace TechnicalTest.App
{
    public class WordLadder
    {
        private readonly ILogger _logger;
        private readonly IWordLadderService _wordLadderService;
        private readonly IFileService _fileService;
        private readonly ApplicationParameters _settings;
        private readonly IEnumerable<OutputStrategy> _outputStrategies;
        public WordLadder(ILogger<WordLadder> logger, IWordLadderService wordLadderService, IFileService fileService, IOptions<ApplicationParameters> settings, IEnumerable<OutputStrategy> outputStrategies)
        {
            _logger = logger;
            _wordLadderService = wordLadderService;
            _fileService = fileService;
            _settings = settings.Value;
            _outputStrategies = outputStrategies;
        }
        internal async Task Start(string[] args)
        {
            _logger.LogInformation($"Application Starting");
            

            var words = await _fileService.GetFileContentsAsync(_settings.DictionaryFile);
            var validWords = await _wordLadderService.FilterValidWords(words);

            await ValidateWordsExistInDictionary(_settings.StartWord, _settings.EndWord, validWords);

            var graphNodes = await _wordLadderService.CreateGraph(_settings.StartWord, _settings.EndWord, validWords);

            var numberOfChanges = await _wordLadderService.GetNumberOfChanges(graphNodes);
            var wordLadder = _wordLadderService.GetWordLadder(graphNodes, _settings.EndWord, numberOfChanges);

            foreach (var strategy in _outputStrategies)
            {
                await strategy.OutputData(wordLadder);
            }
                   
        }

        private async Task ValidateWordsExistInDictionary(string startWord, string endWord, List<string> validWords)
        {
            if (!validWords.Contains(startWord))
            {
                throw new ArgumentException("StartWord not in validWords");
            }

            if (!validWords.Contains(endWord))
            {
                throw new ArgumentException("EndWord not in validWords");
            }

        }

        internal void HandleGlobalError(Exception ex)
        {
            _logger.LogError($"An error occurred: {ex.Message}");
        }

    }
}
