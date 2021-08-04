using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TechnicalTest.App
{
    public class ArgumentValidator : IArgumentValidator
    {
        protected const int CommandLineArgsCount = 4;
        protected const int ExpectedWordLength = 4;

        private readonly ILogger<IArgumentValidator> _logger;

        public ArgumentValidator(ILogger<ArgumentValidator> logger)
        {
            _logger = logger;
        }
       
        public void ValidateArguments(string[] args)
        {
            _logger.LogInformation("Validating command line arguments.");

            if (args.Length == 0)
            {
                throw new ArgumentException("No command line arguments found.");
            }
            if (args.Length != CommandLineArgsCount)
            {
                throw new ArgumentException($"Incorrect number of command line arguments. Found: {args.Length}, Expected: {CommandLineArgsCount}");
            }
          
            if (args[1].Length != ExpectedWordLength)
            {
                throw new ArgumentException("StartWord must be 4 characters");
            }

            if (args[2].Length != ExpectedWordLength)
            {
                throw new ArgumentException("EndWord must be 4 characters");
            }

            if (!File.Exists(args[0]))
            {
                throw new FileNotFoundException("Input file not found or not accessible.");
            }

            _logger.LogInformation("Command line arguments validated.");

        }
    }
}
