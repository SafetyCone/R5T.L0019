using System;

using Newtonsoft.Json;


namespace R5T.L0019.X001
{
    public static class Utilities
    {
        /// <summary>
        /// Gets a <see cref="JsonSerializer"/> configured to produce indented JSON suitable for serialization to files.
        /// </summary>
        public static JsonSerializer GetStandardJsonSerializer(Formatting formatting = JsonHelper.DefaultFormatting)
        {
            var jsonSerializer = new JsonSerializer
            {
                Formatting = formatting,
            };

            return jsonSerializer;
        }
    }
}
