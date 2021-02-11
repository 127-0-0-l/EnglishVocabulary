using System.Collections.Generic;

namespace EnglishVocabulary
{
    class Subtopic
    {
        public int Id { get; set; }
        List<(string Eng, string Rus)> Words { get; set; }
    }
}
