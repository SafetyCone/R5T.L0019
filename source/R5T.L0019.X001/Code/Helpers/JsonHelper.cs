using System;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using R5T.Magyar.IO;


namespace Newtonsoft.Json
{
    public static class JsonHelper
    {
        public const Formatting DefaultFormatting = Formatting.Indented;


        public static string ToJsonString<T>(T value, Formatting formatting = JsonHelper.DefaultFormatting)
        {
            var json = JsonConvert.SerializeObject(value, formatting);
            return json;
        }

        public static T FromJsonstring<T>(string value)
        {
            var output = JsonConvert.DeserializeObject<T>(value);
            return output;
        }

        /// <summary>
        /// A quality-of-life name for <see cref="FromJsonstring{T}(string)"/>.
        /// </summary>
        public static T ToObject<T>(string value)
        {
            return JsonHelper.FromJsonstring<T>(value);
        }

        public static async Task<JObject> LoadAsJObject(string jsonFilePath)
        {
            using var streamReader = StreamReaderHelper.New(jsonFilePath);
            using var jsonTextReader = new JsonTextReader(streamReader);

            var output = await JObject.LoadAsync(jsonTextReader);
            return output;
        }
    }
}
