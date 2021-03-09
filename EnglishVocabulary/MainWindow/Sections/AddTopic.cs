using System;
using System.Linq;
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

                // Get text from rich text box with words.
                string inputText = new TextRange(
                        rtbAddTopicAllWords.Document.ContentStart,
                        rtbAddTopicAllWords.Document.ContentEnd).Text;

                // If there any empty field.
                if (tbAddTopicTopic.Text.Length == 0 || inputText.Length == 0)
                {
                    throw new Exception("Fields must be filled");
                }

                // Lines with "=" is lines with words and their translates.
                // So if first line contains "=" then there no subtopic name.
                if (new Regex(".+").Matches(inputText)[0].ToString().Contains('='))
                {
                    throw new Exception("Add at least one subtopic name");
                }

                topic.TopicName = tbAddTopicTopic.Text;

                Regex regexSubtopics = new Regex(@"[- \w]+\r(.+=.+|\n|\r)+");
                Regex regexSuntopicName = new Regex(@"(^|\n)[- \w]+\r");
                Regex regexWord = new Regex(".+=.+");
                Regex regexWordLeft = new Regex(".+=");
                Regex regexWordRight = new Regex("=.+");

                // Find subtopics with their words.
                MatchCollection subtopics = regexSubtopics.Matches(inputText);

                foreach (var subtopic in subtopics)
                {
                    topic.Subtopic = new Subtopic();

                    // Get subtopic name from
                    // subtopic (subtopic name with words).
                    topic.Subtopic.SubtopicName = 
                        regexSuntopicName.Match(subtopic.ToString()).
                        ToString().
                        Replace('\r', ' ');

                    // Add words in subtopic.
                    foreach (var word in regexWord.Matches(subtopic.ToString()))
                    {
                        topic.Subtopic.Words.Add((
                            regexWordLeft.
                                Match(word.ToString()).
                                ToString().
                                Replace('=', ' '),
                            regexWordRight.
                                Match(word.ToString()).
                                ToString().
                                Replace('=', ' ').
                                Replace('\r', ' ')
                        ));
                    }

                    // Write all data in database (if no exist already).
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