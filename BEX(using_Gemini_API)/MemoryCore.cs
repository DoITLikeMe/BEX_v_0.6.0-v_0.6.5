using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BEX_using_Gemini_API_
{
    internal class MemoryCore
    {
        public BEXMEMORY Memory { get; set; }

        private string _path = "data.json";
        public void LoadData()
        {
            string json = File.ReadAllText(_path);
            Memory = JsonSerializer.Deserialize<BEXMEMORY>(json);
            
        }

        public void SaveData()
        {
            string json = JsonSerializer.Serialize(Memory, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(_path, json);
            Console.WriteLine("Data Saved :D");
        }


        public MemoryToAdd memoadd { get; set; }
        public void AddData(string text)
        {
            LoadData();
            string memoryadd = text.Replace("```", "").Replace("json", "");
            memoadd = JsonSerializer.Deserialize<MemoryToAdd>(memoryadd);
            Memory.Notes.AddRange(memoadd.Notes);
            SaveData();
        }
    }
}
