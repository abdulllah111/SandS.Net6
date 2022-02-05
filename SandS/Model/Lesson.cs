using System.Text.Json.Serialization;

namespace SandS.Model
{
    public class Lesson
    {
        [JsonPropertyName("idlesson")]
        public int IdLesson { get; set; }
        [JsonPropertyName("lesson_number")]
        public int LessonNumber { get; set; }
    }
}
