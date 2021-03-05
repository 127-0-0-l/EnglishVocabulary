using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            try
            {
                Topic topic = new Topic();
                topic.Subtopic = new Subtopic();
                topic.Subtopic.Words = new List<(string Eng, string Rus)>();

                string inputText = new TextRange(
                        rtbAddTopicAllWords.Document.ContentStart,
                        rtbAddTopicAllWords.Document.ContentEnd).Text;

                // If there any empty field.
                if (tbAddTopicTopic.Text.Length == 0 || inputText.Length == 0)
                {
                    throw new Exception("Fields must be filled");
                }

                // If there is no subtopic name.
                if (new Regex(".+").Matches(inputText)[0].ToString().Contains('='))
                {
                    throw new Exception("Add at least one subtopic name");
                }

                topic.TopicName = tbAddTopicTopic.Text;

                Regex regexSubtopics = new Regex(@"[- \w]+\r(.+=.+|\n|\r)+");
                Regex regexSuntopicName = new Regex(@"(^|\n)[- \w]+\r");
                Regex regexWord = new Regex(".+=.+");
                Regex regexEngWord = new Regex(".+=");
                Regex regexRusWord = new Regex("=.+");

                MatchCollection subtopics = regexSubtopics.Matches(new TextRange(
                    rtbAddTopicAllWords.Document.ContentStart,
                    rtbAddTopicAllWords.Document.ContentEnd).Text);

                foreach (var subtopic in subtopics)
                {
                    topic.Subtopic.SubtopicName = regexSuntopicName.Match(subtopic.ToString()).ToString().Replace('\r', ' ');

                    foreach (var word in regexWord.Matches(subtopic.ToString()))
                    {
                        topic.Subtopic.Words.Add((
                            regexEngWord.Match(word.ToString()).ToString().Replace('=', ' '),
                            regexRusWord.Match(word.ToString()).ToString().Replace('=', ' ')));
                    }

                    DataBase.CreateTopic(topic);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
    }
}