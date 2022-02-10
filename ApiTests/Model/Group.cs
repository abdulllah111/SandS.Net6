using System.Text.Json.Serialization;

namespace ApiTests.Model
{
    public class Group
    {
        [JsonPropertyName("idgroup")]
        public int IdGroup { get; set; }
        [JsonPropertyName("group_name")]
        public string Name { get; set; }
        [JsonPropertyName("iddepartment")]
        public int IdDepartment { get; set; }
    }
}
