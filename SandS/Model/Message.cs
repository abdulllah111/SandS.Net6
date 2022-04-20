using System.Text.Json.Serialization;

namespace SandS.Model
{
    internal class Message
    {
        [JsonPropertyName("message")]
        public string message { get; set; }
    }
}
