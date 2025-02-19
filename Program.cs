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
            Console.WriteLine("Error: Dictionary file not found.");
            return;
        }

        
        string jsonText = File.ReadAllText(jsonFilePath);

        
        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonText);

        
        if (dictionary == null || !dictionary.ContainsKey("english_to_sindarin") || !dictionary.ContainsKey("sindarin_to_english"))
        {
            Console.WriteLine("Error: Invalid or corrupt dictionary format.");
            return;
        }

        
        while (true)
        {
            
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("Welcome to the Sindarin Dictionary!");
            Console.WriteLine("******************************************");
            Console.WriteLine("1. Translate from English to Sindarin");
            Console.WriteLine("2. Translate from Sindarin to English");
            Console.WriteLine("3. Exit");
            Console.WriteLine("******************************************");
            Console.Write("Please choose an option (1-3): ");

            string? choice = Console.ReadLine()?.Trim();

            if (choice == "1")
            {
                
                Translate(dictionary, "english_to_sindarin");
            }
            else if (choice == "2")
            {
                
                Translate(dictionary, "sindarin_to_english");
            }
            else if (choice == "3")
            {
                 Console.Write("\nAre you sure you want to exit? (y/n): ");
                 if (Console.ReadLine()?.Trim().ToLower() == "y")
                 {
                Console.WriteLine("\nThank you for using the Sindarin Dictionary. Goodbye!");
                break;
                 }
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please select a valid option (1-3).");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

                System.Threading.Thread.Sleep(1000);
            }
        }
    }

    static void Translate(Dictionary<string, Dictionary<string, string>> dictionary, string languagePair)
    {
        string? input;
        string translation;

        Console.Clear();
        Console.WriteLine($"Enter a word to translate from {languagePair.Replace('_', ' ')} (or type 'exit' to go back to the main menu):");

        
        while (true)
        {
            
            input = Console.ReadLine()?.ToLower();

            
            if (string.IsNullOrEmpty(input) || input == "exit")
                break;

            
            if (input != null && dictionary[languagePair].ContainsKey(input))
            {
                translation = dictionary[languagePair][input];
                Console.WriteLine($"Translation: {translation}");
            }
            else
            {
                Console.WriteLine($"Sorry, '{input}' not found in the dictionary.");
            }

            Console.WriteLine("Enter another word or type 'exit' to go back:");
        }
    }
}
