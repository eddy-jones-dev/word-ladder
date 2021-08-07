using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Domain.Services;

namespace TechnicalTest.Domain.Interfaces
{
    public interface IWordLadderService
    {
        Task<List<string>> GetNextWords(string startWord, List<string> validWords);
        Task<List<string>> FilterValidWords(string[] dictionary);
        Task<int> GetDifference(string startWord, string validWord);
        List<string> GetWordLadder(List<Node> nodes, string endWord, int level);
        Task<List<Node>> CreateGraph(string startWord, string endWord, List<string> validWords);
        Task<int> GetNumberOfChanges(List<Node> graph);
    }
}
