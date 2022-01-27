using System.Text.Json.Serialization;
namespace SandS.Model
{
    public class Department
    {
        [JsonPropertyName("iddepartment")]
        public int IdDepartment { get; set; }
        [JsonPropertyName("department_name")]
        public string Name { get; set; }
    }
}
