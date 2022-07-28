using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using CzasPracy;


namespace JsonInNET
{
    static class JsonFileUtils
    {
        public static void Serialize(object obj, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<Day> Deserialize(string fileName)
        {
            var jsonReadText = File.ReadAllText(fileName);
            List<Day> data1 = JsonConvert.DeserializeObject<List<Day>>(jsonReadText);

            return data1;
        }
    }
}
