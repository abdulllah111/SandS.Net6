using System.Text.Json.Serialization;

namespace ApiTests.Model
{
    public class WeekDay
    {
        [JsonPropertyName("idweekday")]
        public int IdWeekDay { get; set; }
        [JsonPropertyName("weekday_name")]
        public string Name { get; set; }
    }
}
