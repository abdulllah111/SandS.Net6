using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SandS.Model.helpClasses
{
    public class DgtAndTtables
    {
        [JsonPropertyName("iddiscipline-group-teacher")]
        public int Id { get; set; }

        [JsonPropertyName("idteacher")]
        public int IdTeacher { get; set; }

        [JsonPropertyName("iddiscipline")]
        public int IdDiscipline { get; set; }

        [JsonPropertyName("idgroup")]
        public int IdGroup { get; set; }

        [JsonPropertyName("ttables")]
        public List<TTable> Ttables { get; set; }
    }
}
