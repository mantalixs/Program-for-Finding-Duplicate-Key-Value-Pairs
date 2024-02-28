using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        
        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
        {
            { "key1", "value1" },
            { "key2", "value2" },
            { "key3", "value3" },
            { "key4", "value2" } 
        };

        
        Dictionary<string, string> result = FindDuplicateValues(keyValuePairs);

        
        Console.WriteLine("Знайдені пари з однаковим значенням:");
        foreach (var pair in result)
        {
            Console.WriteLine($"Ключ: {pair.Key}, Значення: {pair.Value}");
        }

        
        SaveResultToJson(result, "result.json");
    }

    static Dictionary<string, string> FindDuplicateValues(Dictionary<string, string> inputDictionary)
    {
        Dictionary<string, string> resultDictionary = new Dictionary<string, string>();
        HashSet<string> uniqueValues = new HashSet<string>();

        foreach (var pair in inputDictionary)
        {
            
            if (!uniqueValues.Add(pair.Value))
            {
                resultDictionary.Add(pair.Key, pair.Value);
            }
        }

        return resultDictionary;
    }

    static void SaveResultToJson(Dictionary<string, string> result, string fileName)
    {
        
        string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
        File.WriteAllText(fileName, jsonResult);
        Console.WriteLine($"Результат збережено у файл {fileName}");
    }
}