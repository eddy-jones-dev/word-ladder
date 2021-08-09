using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Domain.Interfaces
{
    public interface IFileService
    {
        Task<string[]> GetFileContentsAsync(string path);
        Task WriteResutsToFile(List<string> wordLadder, string filePath);
    }
}
