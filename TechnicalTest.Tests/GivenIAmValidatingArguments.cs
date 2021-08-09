using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.IO;
using TechnicalTest.App;
using TechnicalTest.Domain;
using Xunit;

namespace TechnicalTest.Tests
{
    public class GivenIAmValidatingArguments
    {
        private Mock<ILogger<ArgumentValidator>> _loggerMock;
        private ArgumentValidator _sut;
        public GivenIAmValidatingArguments()
        {
            _loggerMock = new Mock<ILogger<ArgumentValidator>>();
            _sut = new ArgumentValidator(_loggerMock.Object);
        }


        [Fact]
        public void WhenIPassNoParameters_ThenIGetAnError()
        {
            string[] args = new string[0];
            Assert.Throws<ArgumentException>(() => _sut.ValidateArguments(args));
        }

        [Fact]
        public void WhenTheNumberOfParamsIsWrong_ThenIGetAnError()
        {
            string[] args = new string[] { "F:\\somefile.txt", "Spin", "Spot"};
            
            Assert.Throws<ArgumentException>(() => _sut.ValidateArguments(args));
        }

        [Fact]
        public void WhenTheInputFileDoesNotExist_ThenIGetAnError()
        {
            string[] args = new string[] { "F:\\somefile.txt","Spin","Spot","F:\\output.txt"};
            Assert.Throws<FileNotFoundException>(() => _sut.ValidateArguments(args));
        }

        [Fact]
        public void WhenTheStartWordLengthIsIncorrect_ThenIGetAnError()
        {
            string[] args = new string[] { "F:\\somefile.txt", "Cat", "Spot", "F:\\output.txt" };
            Assert.Throws<ArgumentException>(() => _sut.ValidateArguments(args));
        }
    }
}
