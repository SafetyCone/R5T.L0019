using System;
using System.IO;

using R5T.Magyar.IO;


namespace Newtonsoft.Json
{
    public static class JsonSerializerExtensions
    {
        public static void Serialize<T>(this JsonSerializer jsonSerializer, string jsonFilePath, T value, bool overwrite = true)
        {
            using var fileStream = FileStreamHelper.NewWrite(jsonFilePath, overwrite);
            using var streamWriter = new StreamWriter(fileStream);

            jsonSerializer.Serialize(streamWriter, value);
        }

        public static T Deserialize<T>(this JsonSerializer jsonSerializer, string jsonFilePath)
        {
            using var textReader = File.OpenText(jsonFilePath);
            using var jsonReader = new JsonTextReader(textReader);

            var value = jsonSerializer.Deserialize<T>(jsonReader);
            return value;
        }
    }
}
