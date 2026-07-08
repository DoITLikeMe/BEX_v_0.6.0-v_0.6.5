using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEX_using_Gemini_API_
{
    internal class BEXMEMORY
    {
        public User User { get; set; }
        public List<string> Notes { get; set; }
       
    }
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Interests { get; set; }
    }
}
