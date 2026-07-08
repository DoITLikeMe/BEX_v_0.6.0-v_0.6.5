using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEX_using_Gemini_API_
{
    internal class MemoryToAdd
    {
        public string Action { get; set; }
        public List<string> Notes { get; set; } = new();
    }
}
