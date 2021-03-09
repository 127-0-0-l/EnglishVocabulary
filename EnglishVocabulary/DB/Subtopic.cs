using System.Collections.Generic;

namespace EnglishVocabulary
{
    class Subtopic
    {
        public string SubtopicName { get; set; }
        public List<(string Left, string Right)> Words { get; set; } = new List<(string Left, string Right)>();
    }
}
