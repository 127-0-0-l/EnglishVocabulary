using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EnglishVocabulary
{
    class Vocabulary
    {
        [Key]
        public int Page { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
