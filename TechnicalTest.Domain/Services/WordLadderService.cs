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
            _logger.LogInformation("Filtering dictionary for valid words");
            return dictionary.Where(word => word.Length == WordLength)
                            .Select(word => word.ToLowerInvariant())
                            .ToList();
        }

        public async Task<List<string>> GetNextWords(string startWord, List<string> validWords)
        {
            var result = new List<string>();

            foreach (var word in validWords)
            {
                if (await GetDifference(startWord, word) == 1)
                {
                    result.Add(word);
                }
            }

            return result;
        }

        public async Task<int> GetNumberOfChanges(List<Node> graph)
        {
            return graph.Select(node => node.Level).OrderByDescending(node => node).First();
        }

        public async Task<int> GetDifference(string startWord, string validWord)
        {
            return startWord
                .ToCharArray()
                .Zip(validWord.ToCharArray(), (char1, char2) => new CharComparison { Char1 = char1, Char2 = char2 })
                .Count(charComparision => charComparision.Char1 != charComparision.Char2);
        }


        public async Task<List<Node>> CreateGraph(string startWord, string endWord, List<string> validWords)
        {
            var result = new List<Node>();

            var queue = new Queue<string>();
            queue.Enqueue(startWord);

            var level = 0;
            var allLevelWords = new Queue<string>();
            while (queue.Count > 0)
            {

                var workingWord = queue.Dequeue();
                var nextWords = await GetNextWords(workingWord, validWords);

                foreach (var word in nextWords)
                {
                    result.Add(new Node
                    {
                        Level = level,
                        ParentNode = workingWord,
                        ChildNode = word,
                        NodePath = GetPredecessor(level, workingWord, result)
                    });

                    allLevelWords.Enqueue(word);
                }

                if (queue.Contains(endWord))
                {
                    break;
                }

                if (queue.Count == 0)
                {
                    level++;
                    foreach (var queueItem in allLevelWords)
                    {
                        queue.Enqueue(queueItem);
                    }
                }
            }

            return result;


        }

        private List<string> GetPredecessor(int level, string workingWord, List<Node> graph)
        {
            var result = graph.FirstOrDefault(node => node.Level == (level - 1) && node.ChildNode == workingWord);
            return result?.NodePath ?? new List<string>();
        }


    }
}
