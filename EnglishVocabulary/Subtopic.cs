using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishVocabulary
{
    class Subtopic
    {
        public string SubtopicName { get; set; }
        public List<(string Eng, string Rus)> Words { get; set; }
    }
}
