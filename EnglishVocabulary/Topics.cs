using System.ComponentModel.DataAnnotations;

namespace EnglishVocabulary
{
    class Topics
    {
        [Key]
        public int page { get; set; }
        public Topic topic { get; set; }
    }
}
