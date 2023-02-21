using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace La.WebApi.Framework
{
    /// <summary>
    /// JsonConverterUtil
    /// </summary>
    public class JsonConverterUtil
    {
        /// <summary>
        /// JsonConverter
        /// </summary>
        public class DateTimeNullConverter : JsonConverter<DateTime?>
        {
            /// <summary>
            /// Read
            /// </summary>
            /// <param name="reader"></param>
            /// <param name="typeToConvert"></param>
            /// <param name="options"></param>
            /// <returns></returns>
            public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => string.IsNullOrEmpty(reader.GetString()) ? default(DateTime?) : ParseDateTime(reader.GetString()!);
            /// <summary>
            /// Write
            /// </summary>
            /// <param name="writer"></param>
            /// <param name="value"></param>
            /// <param name="options"></param>
            public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
                => writer.WriteStringValue(value?.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        /// <summary>
        /// JsonConverter
        /// </summary>
        public class DateTimeConverter : JsonConverter<DateTime>
        {
            /// <summary>
            /// Read
            /// </summary>
            /// <param name="reader"></param>
            /// <param name="typeToConvert"></param>
            /// <param name="options"></param>
            /// <returns></returns>
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var dateTime = ParseDateTime(reader.GetString()!);
                return dateTime == null ? DateTime.MinValue : dateTime.Value;
            }
            /// <summary>
            /// Write
            /// </summary>
            /// <param name="writer"></param>
            /// <param name="value"></param>
            /// <param name="options"></param>

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
                => writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        /// <summary>
        /// ParseDateTime
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>

        public static DateTime? ParseDateTime(string dateStr)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(dateStr, @"^\d{4}[/-]") && DateTime.TryParse(dateStr, null,System.Globalization.DateTimeStyles.AssumeLocal, out var dateVal))
                return dateVal;
            return null;
        }
    }
}
