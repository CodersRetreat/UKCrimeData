using System;
using CrimeDataUK.Constants;
using Newtonsoft.Json;

namespace CrimeDataUK.Models
{
    public partial class ForceDetails
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("engagement_methods")]
        public EngagementMethod[] EngagementMethods { get; set; }

        [JsonProperty("telephone")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Telephone { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public string ForceSeniorOfficerUrl()
        {
            return ApiUrls.ForcesSeniorOfficers + "/" + Id + "/people";
        }
    }
}
internal class ParseStringConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        long l;
        if (Int64.TryParse(value, out l))
        {
            return l;
        }
        throw new Exception("Cannot unmarshal type long");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (long)untypedValue;
        serializer.Serialize(writer, value.ToString());
        return;
    }

    public static readonly ParseStringConverter Singleton = new ParseStringConverter();
}