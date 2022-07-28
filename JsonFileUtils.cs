using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;


namespace JsonInNET
{
    public static class JsonFileUtils
    {
        private static readonly JsonSerializerSettings _options = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public static void SimpleWrite(object obj, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(obj, _options);
            File.WriteAllText(fileName, jsonString);
        }

        public static void PrettyWrite(object obj, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, _options);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
