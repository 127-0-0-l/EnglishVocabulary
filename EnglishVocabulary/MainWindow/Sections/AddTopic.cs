using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            if(tbAddTopicTopic.Text.Length > 0 &&
                new TextRange(
                    rtbAddTopicAllWords.Document.ContentStart,
                    rtbAddTopicAllWords.Document.ContentEnd).Text.Length > 0)
            {
                topic.TopicName = tbAddTopicTopic.Text;

                Regex regexSubtopics = new Regex(@"^[ \w]+\n(.+=.+|\n)+$");
                MatchCollection collection = regexSubtopics.Matches(new TextRange(
                    rtbAddTopicAllWords.Document.ContentStart,
                    rtbAddTopicAllWords.Document.ContentEnd).Text);
                MessageBox.Show(collection.Count.ToString());
                return;
            }
            else
            {
                MessageBox.Show("Fields must be filled");
                return;
            }

            DataBase.CreateTopic(topic);
        }
    }
}