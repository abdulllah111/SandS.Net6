using System.Text.Json.Serialization;

namespace SandS.Model
{
    public class Teacher
    {
        [JsonPropertyName("idteacher")]
        public int IdTeacher { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
