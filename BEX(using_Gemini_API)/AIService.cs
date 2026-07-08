using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BEX_using_Gemini_API_
{
    internal class AIService
    {
        private MemoryCore core { get; set; }
        private readonly PromptManager _prompt = new PromptManager();
        private HttpClient _http;
        private static string apiKey = Environment.GetEnvironmentVariable("GEMINI-API-KEY");
        private string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}";

        public async Task<string> AISystem(string prompt)
        {
            _http = new HttpClient();

            if (prompt != null)
            {
                var RequestBody = new
                {
                    systemInstruction = new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text =_prompt.SystemPrompt
                            }
                        }
                    },
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new
                                {
                                    text = prompt
                                }
                            }
                        }
                    }
                };

                string json = JsonSerializer.Serialize(RequestBody);
                var response = await _http.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                string answer = await response.Content.ReadAsStringAsync();
                var jsondoc = JsonDocument.Parse(answer);
                string? text = jsondoc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();
                Console.WriteLine();
                Console.WriteLine("BEX: ");
                core = new MemoryCore();
                if (text.StartsWith("```"))
                    core.AddData(text);
                else
                    return text ?? "";


            }
            return "";

        }

        private bool IsJson()
        {
            return true;
        }


    }
}
