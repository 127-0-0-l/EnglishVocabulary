using System.ComponentModel.DataAnnotations;

namespace EnglishVocabulary
{
    class Topic
    {
        public int Id { get; set; }
        public Subtopic subtopic { get; set; }
    }
}
