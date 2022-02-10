using System.Text.Json.Serialization;

namespace ApiTests.Model
{
    public class Discipline
    {
        [JsonPropertyName("iddiscipline")]
        public int IdDiscipline { get; set; }
        [JsonPropertyName("discipline_name")]
        public string Name { get; set; }
    }
}
