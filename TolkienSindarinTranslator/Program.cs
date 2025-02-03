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
    }
}