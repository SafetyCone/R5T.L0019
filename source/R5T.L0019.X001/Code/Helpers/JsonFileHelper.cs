using System;
using System.IO;
using System.Threading.Tasks;

using LibraryUtilities = R5T.L0019.X001.Utilities;


namespace Newtonsoft.Json
{
    public static class JsonFileHelper
    {
        public static T LoadFromFile<T>(string jsonFilePath)
        {
            var serializer = LibraryUtilities.GetStandardJsonSerializer();

            var output = serializer.Deserialize<T>(jsonFilePath);
            return output;
        }

        /// <summary>
        /// Loads from the given JSON file path, or calls the default constructor if the file does not exist.
        /// </summary>
        public static T LoadFromFileOrDefault<T>(
            string jsonFilePath,
            Func<T> defaultConstructor)
        {
            var fileExists = File.Exists(jsonFilePath);
            if(fileExists)
            {
                var output = JsonFileHelper.LoadFromFile<T>(jsonFilePath);
                if (output is object)
                {
                    return output;
                }
            }

            // Else, default;
            var @default = defaultConstructor();
            return @default;
        }

        public static async Task<T> LoadFromFile<T>(string jsonFilePath, string keyName)
        {
            var jObject = await JsonHelper.LoadAsJObject(jsonFilePath);

            var keyedJObject = jObject[keyName];

            var output = keyedJObject.ToObject<T>();
            return output;
        }

        /// <summary>
        /// No async version since Newtonsoft does not have async!
        /// </summary>
        public static void WriteToFile<T>(string jsonFilePath, T value, Formatting formatting = JsonHelper.DefaultFormatting, bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            var serializer = LibraryUtilities.GetStandardJsonSerializer(formatting);

            serializer.Serialize(jsonFilePath, value, overwrite);
        }
    }
}
