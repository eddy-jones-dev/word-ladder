using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Domain.Interfaces;

namespace TechnicalTest.Domain.Services
{
    public partial class WordLadderService : IWordLadderService
    {

        private readonly ILogger<WordLadderService> _logger;
        private const int WordLength = 4;

        public WordLadderService(ILogger<WordLadderService> logger)
        {
            _logger = logger;
        }

        public async Task<List<string>> FilterValidWords(string[] dictionary)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetDistance(List<string> words)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetNextWords(string startWord, List<string> validWords)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNumberOfChanges(List<Node> graph)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetDifference(string startWord, string validWord)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Node>> CreateGraph(string startWord, string endWord, List<string> validWords)
        {
            throw new NotImplementedException();
        }

    }
}
