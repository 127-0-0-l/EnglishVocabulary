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
            if(cbTestHeaderTopic.SelectedItem != null)
            {
                string topicName = cbTestHeaderTopic.SelectedItem.ToString();
                cbTestHeaderSubtopic.ItemsSource = DataBase.GetSubtopics(topicName);
                cbTestHeaderSubtopic.IsEnabled = true;
            }
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
            StartTest();
            ShowTestGrid();
            ResetTestHeader();
        }

        private void ShowTestGrid()
        {
            grdTestTest.Visibility = Visibility.Visible;
            grdTestHeader.Visibility = Visibility.Hidden;
        }

        private void ResetTestHeader()
        {
            cbTestHeaderTopic.Text = "";
            cbTestHeaderSubtopic.Text = "";
            cbTestHeaderSubtopic.IsEnabled = false;
            cbTestHeaderMode.Text = "";
            cbTestHeaderMode.IsEnabled = false;
            btnTestHeaderStart.IsEnabled = false;
        }

        private void StartTest()
        {

        }
    }
}
