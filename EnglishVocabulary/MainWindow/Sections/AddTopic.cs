using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        /// <summary>
        /// Add new topic to Database.
        /// </summary>
        private void btnAddTopicAdd_Click(object sender, RoutedEventArgs e)
        {
            Topic topic = new Topic();
            topic.TopicName = "TopicFirst";

            topic.Subtopic = new Subtopic();
            topic.Subtopic.SubtopicName = "SubtopicFirst";

            topic.Subtopic.Words = new List<(string Eng, string Rus)>();
            topic.Subtopic.Words.Add(("english", "английский"));
            topic.Subtopic.Words.Add(("dog", "собака"));
            topic.Subtopic.Words.Add(("cat", "кот"));
            topic.Subtopic.Words.Add(("house", "дом"));
            topic.Subtopic.Words.Add(("plane", "самолет"));
            topic.Subtopic.Words.Add(("button", "кнопка"));
            topic.Subtopic.Words.Add(("headphones", "наушники"));
            topic.Subtopic.Words.Add(("table", "таблица/стол"));
            topic.Subtopic.Words.Add(("word", "слово"));

            DataBase.CreateTopic(topic);
        }
    }
}