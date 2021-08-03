using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTest.App
{
    public class WordLadder
    {
        private readonly ILogger _logger;
        private readonly IArgumentValidator _argumentValidator;
        public WordLadder(ILogger<WordLadder> logger, IArgumentValidator argumentValidator)
        {
            _logger = logger;
            _argumentValidator = argumentValidator;
        }
        internal void Start(string[] args)
        {
            _logger.LogInformation($"Application Starting");
            _argumentValidator.ValidateArguments(args);

            Console.ReadLine();
        }
      
        internal void HandleGlobalError(Exception ex)
        {
            _logger.LogError($"An error occurred: {ex.Message}");
        }

    }
}
