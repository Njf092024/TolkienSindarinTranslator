using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class program
{
    static void Main()
    {
        string JsonFilePath = "sindarin_dictionary.json";

        if (!File.Exists(jsonFilePath))
        {
            Console.WriteLine("Error: Dictionary file not found");
            return;
        }

        string jsonText = File.ReadAllText(jsonFilePath);

        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string >>>(jsonText);
        
        while (true)
        {
            Console.WriteLine("\nEnter a word (English or Sindarin) or type 'exit' to quit:");
            string input = Console.ReadLine()?.ToLower();

            if (input =="exit")
            break;
        }
    }
}