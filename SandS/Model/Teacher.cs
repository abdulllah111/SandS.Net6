using System.Text.Json.Serialization;

namespace SandS.Model
{
    public class Teacher
    {
        [JsonPropertyName("idteacher")]
        public int IdTeacher { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("login")]
        public string? Login { get; set; }
        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }
}
