using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string jsonFilePath = "sindarin_dictionary.json";

        if (!File.Exists(jsonFilePath))
        {
            Console.WriteLine("Error: Dictionary file not found");
            return;
        }

        string jsonText = File.ReadAllText(jsonFilePath);

        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string >>>(jsonText)
        ?? new Dictionary<string, Dictionary<string, string>>();
        
        while (true)
        {
            Console.WriteLine("\nEnter a word (English or Sindarin) or type 'exit' to quit:");
            string input = Console.ReadLine()?.ToLower();

            if (input =="exit")
            break;

            if (dictionary["english_to_sindarin"].TryGetValue(input, out string sindarinWord))
            {
                Console.WriteLine($"Sindarin Translation: {sindarinWord}");
            }
            else if (dictionary["sindarin_to_english"].TryGetValue(input, out string englishWord))
            {
                Console.WriteLine($"English Translation: {englishWord}");
            }
            else
            {
                Console.WriteLine("Word not found in dictionary.");
            }
        }
    }
}