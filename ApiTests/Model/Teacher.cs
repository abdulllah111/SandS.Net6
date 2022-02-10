using System.Text.Json.Serialization;

namespace ApiTests.Model
{
    public class Teacher
    {
        [JsonPropertyName("idteacher")]
        public int IdTeacher { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
