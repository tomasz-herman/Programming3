using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonDeserialization;

public class UnixTimestampConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TryGetInt32(out int timestamp))
            return new DateTime (1970, 1, 1).AddSeconds (timestamp);
        throw new Exception ("Expected the timestamp as a number.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        int timestamp = (int)(value - new DateTime(1970, 1, 1)).TotalSeconds;
        writer.WriteNumberValue(timestamp);
    }
}