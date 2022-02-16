using System.Text.Json.Serialization;
namespace ApiTests.Model
{
    public class Department
    {
        [JsonPropertyName("iddepartment")]
        public int IdDepartment { get; set; }
        [JsonPropertyName("department_name")]
        public string Name { get; set; }
    }
}
