using System.Text.Json.Serialization;

namespace SandS.Model
{
    public class Office
    {
        [JsonPropertyName("idoffice")]
        public int IdOffice { get; set; }
        [JsonPropertyName("office_number")]
        public string OfficeNumber { get; set; }
    }
}
