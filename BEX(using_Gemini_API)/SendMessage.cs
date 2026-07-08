using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEX_using_Gemini_API_
{
    internal class SendMessage
    {
        public string MessageSending()
        {
            Console.WriteLine("---HI! I AM BEX! ASK ME ANYTHING!---");
            Console.WriteLine("User:");
            string? prompt = Console.ReadLine();

            return prompt;
        }
    }
}
