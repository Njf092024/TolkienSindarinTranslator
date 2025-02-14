using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string jsonFilePath = "sindarin_dictionary.json";

        // Check if dictionary file exists
        if (!File.Exists(jsonFilePath))
        {
            Console.WriteLine("Error: Dictionary file not found.");
            return;
        }

        // Read the content of the JSON file
        string jsonText = File.ReadAllText(jsonFilePath);

        // Deserialize the JSON into the dictionary object
        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonText);

        // Check if the dictionary is valid
        if (dictionary == null || !dictionary.ContainsKey("english_to_sindarin") || !dictionary.ContainsKey("sindarin_to_english"))
        {
            Console.WriteLine("Error: Invalid or corrupt dictionary format.");
            return;
        }

        // Main loop for menu and interaction
        while (true)
        {
            // Display the main menu
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
                // English to Sindarin translation
                Translate(dictionary, "english_to_sindarin");
            }
            else if (choice == "2")
            {
                // Sindarin to English translation
                Translate(dictionary, "sindarin_to_english");
            }
            else if (choice == "3")
            {
                // Exit the program
                Console.WriteLine("\nThank you for using the Sindarin Dictionary. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please select a valid option (1-3).");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    static void Translate(Dictionary<string, Dictionary<string, string>> dictionary, string languagePair)
    {
        string? input;
        string translation;

        Console.Clear();
        Console.WriteLine($"Enter a word to translate from {languagePair.Replace('_', ' ')} (or type 'exit' to go back to the main menu):");

        // Loop for translation input
        while (true)
        {
            // Safely read the input and convert it to lowercase
            input = Console.ReadLine()?.ToLower();

            // If input is null or empty, or if the user types "exit", break the loop
            if (string.IsNullOrEmpty(input) || input == "exit")
                break;

            // Fix: Explicitly handle null or empty input
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
