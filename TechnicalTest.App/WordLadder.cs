using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

            var dictionaryFile = args[0];
            var startWord = args[1].ToLowerInvariant();
            var endWord = args[2].ToLowerInvariant();
            var outputFile = args[3];

            var words = await _fileService.GetFileContentsAsync(dictionaryFile);
            var validWords = await _wordLadderService.FilterValidWords(words);

            await ValidateWordsExistInDictionary(startWord, endWord, validWords);

            var graphNodes = await _wordLadderService.CreateGraph(startWord, endWord, validWords);

            var numberOfChanges = await _wordLadderService.GetNumberOfChanges(graphNodes);
            var wordLadder = _wordLadderService.GetWordLadder(graphNodes, endWord, numberOfChanges);
            await _fileService.WriteResutsToFile(wordLadder,outputFile);
            foreach (var node in wordLadder)
            {
                Console.WriteLine(node);
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
