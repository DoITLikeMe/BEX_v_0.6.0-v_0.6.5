using System.Security.Cryptography.X509Certificates;

namespace BEX_using_Gemini_API_
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            var _ai = new AIService();
            var messenger = new SendMessage();

            while (true)
            {
                string prompt = messenger.MessageSending();
                string breaker = prompt.ToLower();
                if (breaker == "stop")
                {
                    break;
                }
                string response = await _ai.AISystem(prompt);
                Console.WriteLine(response);
            }
        }
    }
}
