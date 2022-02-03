using System.Text.Json.Serialization;

namespace SandS.Model
{
    public class Discipline
    {
        [JsonPropertyName("iddiscipline")]
        public int IdDiscipline { get; set; }
        [JsonPropertyName("discipline_name")]
        public string Name { get; set; }
    }
}
