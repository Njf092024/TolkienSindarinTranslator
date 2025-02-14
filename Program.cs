using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string jsonFilePath = "sindarin_dictionary.json";

        if (!File.Exists(jsonFilePath))
        {
          Console.WriteLine("Error: Dictionary file not found");
            return;
        }

        string jsonText = File.ReadAllText(jsonFilePath);

        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string >>>(jsonText);
        
        if (dictionary == null || !dictionary.ContainsKey("english_to_sindarin") || !dictionary.ContainsKey("sindarin_to_english"))
        {
            Console.WriteLine("Error: Invalid or corrupt dictionary format.");
            return;
        }

 
        
        while (true)
        {
            Console.WriteLine("\nEnter a word (English or Sindarin) or type 'exit' to quit:");
            string? input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrEmpty(input) || input  == "exit")
            break;

            if (dictionary["english_to_sindarin"].TryGetValue(input, out string? sindarinWord))
            {
                Console.WriteLine($"Sindarin Translation: {sindarinWord}");
            }
            else if (dictionary["sindarin_to_english"].TryGetValue(input, out string? englishWord))
            {
                Console.WriteLine($"English Translation: {englishWord}");
            }
            else
            {
                Console.WriteLine("Word not found in dictionary. Attempting to translate '{input}' using Google Translate...");

                string TranslatedText = await translateService.TranslateText(input, sourceLang: "en", targetLang: "fr");
                Console.WriteLine($"Translated text: {TranslatedText}");
            }
        }
    }
}