using System.Collections.Generic;

namespace TechnicalTest.Domain.Services
{
        public class Node
        {
            public int Level { get; set; }
            public string ParentNode { get; set; }
            public string ChildNode { get; set; }
            public List<string> NodePath { get; set; }
        }
}
