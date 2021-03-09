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
            grdTestResult.Visibility = Visibility.Hidden;
        }
        
        private void ShowTestResults()
        {
            grdTestTest.Visibility = Visibility.Hidden;
            grdTestHeader.Visibility = Visibility.Visible;
            grdTestResult.Visibility = Visibility.Visible;
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
            List<(string left, string right)> allWords = DataBase.GetWords(cbTestHeaderSubtopic.SelectedItem.ToString());

            int[] indexes = GetRandomUniqueIndexes(0, allWords.Count - 1, allWords.Count - 1);

            int rightAnswersCount = 0;
            int wrongAnswersCount = 0;
            int noAnswersCount = 0;

            btnTestTestNext.Click += (s, a) =>
            {

            };

            btnTestTestFinish.Click += (s, a) =>
            {

            };

            
            string[] GetWordSet((string left, string right) word)
            {
                string[] words = new string[4];
                Random rnd = new Random();

                int translateIndex = rnd.Next(4);

                for (int i = 0; i < 4; i++)
                {
                    if(i == translateIndex)
                    {
                        words[i] = word.right;
                    }
                    else
                    {
                        words[i] = allWords[rnd.Next(allWords.Count)].right;
                    }
                }

                return words;
            }
        }
    }
}
