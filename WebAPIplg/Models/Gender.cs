using System.Text.Json.Serialization;

namespace WebAPIplg.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Nonbinary = 0,
        Male = 1,
        Female = 2,
        Helicopter = 3
    }
}
