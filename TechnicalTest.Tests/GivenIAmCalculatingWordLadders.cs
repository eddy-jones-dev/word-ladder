using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Domain.Services;
using Xunit;

namespace TechnicalTest.Tests
{
    public class GivenIAmCalculatingWordLadders
    {
        private Mock<ILogger<WordLadderService>> _loggerMock;
        private WordLadderService _sut;
        public GivenIAmCalculatingWordLadders()
        {
            _loggerMock = new Mock<ILogger<WordLadderService>>();
            _sut = new WordLadderService(_loggerMock.Object);
        }

       
        [Fact]
        public async Task WhenIWantToCreateAGraph_ThenIGetAPopulatedGraph()
        {
            var startWord = "spin";
            var endWord = "spot";
            var words = new string[] { startWord, endWord, "spit", "spat", "soon", "spun", "shin", "thin" };
            var dictionary = await _sut.FilterValidWords(words);

            var graph = await _sut.CreateGraph(startWord, endWord, dictionary);
            graph.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("spin", "spot", 2)]
        [InlineData("door", "roar", 3)]
        [InlineData("nice", "lice", 1)]
        [InlineData("bank", "dome", 4)]
        public async Task WhenIHaveAGraph_ThenICanGetTheNumberOfChanges(string startWord,string endWord, int numberOfChanges)
        {

            var words = File.ReadAllLines("C:\\words\\words-english\\words-english.txt");
            var dictionary = await _sut.FilterValidWords(words);

            var graph = await _sut.CreateGraph(startWord, endWord, dictionary);
            var result = await _sut.GetNumberOfChanges(graph);
            Node branch;
            try
            {
                branch = graph.First(node => node.ChildNode == endWord && node.Level == result);
                branch.NodePath.Add(endWord);
                foreach (var node in branch.NodePath)
                {
                    Console.WriteLine(node);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            result.Should().Be(numberOfChanges);
        }

        [Fact]
        public async Task WhenIGetNextWords_ThenIGetAllWordsWithOneCharDifference()
        {
            var startWord = "spit";
            
            var words = File.ReadAllLines("C:\\words\\words-english\\words-english.txt");
            var dictionary = await _sut.FilterValidWords(words);

            var result = await _sut.GetNextWords(startWord, dictionary);
            result.Should().Contain("skit");
            result.Should().Contain("spot");
            result.Should().Contain("spin");
            result.Should().NotContain("spun");
            result.Should().NotContain("split");
        }
    }
}
