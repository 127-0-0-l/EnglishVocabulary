using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        private void cbTestHeaderTopic_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string topicName = cbTestHeaderTopic.SelectedItem.ToString();
            cbTestHeaderSubtopic.ItemsSource = DataBase.GetSubtopics(topicName);
            cbTestHeaderSubtopic.IsEnabled = true;
        }

        private void cbTestHeaderSubtopic_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            cbTestHeaderMode.IsEnabled = true;
        }

        private void cbTestHeaderMode_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            btnTestHeaderStart.IsEnabled = true;
        }

        private void btnTestHeaderStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
