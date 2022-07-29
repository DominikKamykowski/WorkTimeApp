using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using CzasPracy;
using System.Linq;


namespace JsonInNET
{
    /// <summary>
    /// Klasa odpowiadająca za połączenie danych z funkcją zapisu oraz odczytu z pliku .json
    /// </summary>
    static class JsonFileUtils
    {
        public static string filePath = @"C:\Users\user\source\repos\CzasPracy\data.json"; // Ścieżka do pliku danych json

        /// <summary>
        /// Funkcja zapisu do pliku json. Wykonuje serializację danych do formatu json.
        /// </summary>
        /// <param name="obj">Obiekt do serializacji</param>
        public static void Serialize(object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Funkcja pobrania surowych danych poddanych deserializacji z pliku .json.
        /// </summary>
        /// <returns>Lista obiektów klasy Day po deserializacji</returns>
        public static List<Day> Deserialize()
        {
            var jsonReadText = File.ReadAllText(filePath);
            List<Day> data1 = JsonConvert.DeserializeObject<List<Day>>(jsonReadText);

            return data1;
        }

        /// <summary>
        /// Funkcja pobrania listy posortowanych obiektów .json.
        /// </summary>
        /// <returns>Lista obiektów klasy Day poddana sortowaniu</returns>
        public static List<Day> GetSortedList()
        {
            var deserializedList = Deserialize();
            var sortedList = deserializedList.OrderBy(x => x.Date).ToList();
            return sortedList;
        }
    }
}
