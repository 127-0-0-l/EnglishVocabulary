using System.Windows;
using System.Windows.Controls;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        private void cbDeleteTopicTopic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbDeleteTopicTopic.SelectedItem != null)
            {
                string topicName = cbDeleteTopicTopic.SelectedItem.ToString();
                cbDeleteTopicSubtopic.ItemsSource = DataBase.GetSubtopics(topicName);
                cbDeleteTopicSubtopic.IsEnabled = true;
            }
        }

        private void cbDeleteTopicSubtopic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbDeleteTopicSubtopic.SelectedItem != null)
            {
                btnDeleteTopicDelete.IsEnabled = true;
            }
        }

        private void btnDeleteTopicDelete_Click(object sender, RoutedEventArgs e)
        {
            string topicName = cbDeleteTopicTopic.SelectedItem.ToString();
            string subtopicName = cbDeleteTopicSubtopic.SelectedItem.ToString();
            DataBase.DeleteSubtopic(topicName, subtopicName);

            ResetDeleteTopicSection();
        }

        private void ResetDeleteTopicSection()
        {
            cbDeleteTopicTopic.Text = "";
            cbDeleteTopicSubtopic.Text = "";
            cbDeleteTopicSubtopic.IsEnabled = false;
            btnDeleteTopicDelete.IsEnabled = false;
        }
    }
}
