using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Domain.Strategies
{
    public abstract class OutputStrategy
    {
        
        public abstract Task OutputData(List<string> wordLadder);
    }
}
