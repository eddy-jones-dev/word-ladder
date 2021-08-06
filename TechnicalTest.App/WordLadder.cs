using Microsoft.Extensions.Logging;
using System;
using System.IO;
using TechnicalTest.Domain;
using TechnicalTest.Domain.Interfaces;

namespace TechnicalTest.App
{
    public class WordLadder
    {
        private readonly ILogger _logger;
        private readonly IArgumentValidator _argumentValidator;
        private readonly IWordLadderService _service;
        public WordLadder(ILogger<WordLadder> logger, IArgumentValidator argumentValidator, IWordLadderService service)
        {
            _logger = logger;
            _argumentValidator = argumentValidator;
            _service = service;
        }
        internal void Start(string[] args)
        {
            _logger.LogInformation($"Application Starting");
            _argumentValidator.ValidateArguments(args);

            var words = File.ReadAllLines("C:\\words\\words-english\\words-english.txt");

            var StartWord = "Spin".ToLowerInvariant();
            var EndWord = "Spot".ToLowerInvariant();

            var validWords = _service.FilterValidWords(words);
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
