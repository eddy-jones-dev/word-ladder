using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Domain.Strategies
{
    public class ConsoleOutputStrategy : OutputStrategy
    {
        public override Task OutputData(List<string> wordLadder)
        {
            foreach (var node in wordLadder)
            {
                Console.WriteLine(node);
            }
            return Task.CompletedTask;
        }
    }
}
