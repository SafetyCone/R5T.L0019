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
