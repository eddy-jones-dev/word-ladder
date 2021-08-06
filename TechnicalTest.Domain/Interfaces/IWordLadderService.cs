using System;
using System.Collections.Generic;
using System.Text;
using TechnicalTest.Domain.Services;

namespace TechnicalTest.Domain.Interfaces
{
    public interface IWordLadderService
    {
        List<string> GetNextWords(string startWord, List<string> validWords);
        List<string> FilterValidWords(string[] dictionary);
        int GetDistance(List<string> words);
        List<Node> CreateGraph(string startWord, string endWord, List<string> validWords);
        int GetNumberOfChanges(List<Node> graph);
    }
}
