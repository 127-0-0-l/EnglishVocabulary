using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        private void cbTestHeaderTopic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbTestHeaderTopic.SelectedItem != null)
            {
                string topicName = cbTestHeaderTopic.SelectedItem.ToString();
                cbTestHeaderSubtopic.ItemsSource = DataBase.GetSubtopics(topicName);
                cbTestHeaderSubtopic.IsEnabled = true;

                cbTestHeaderSubtopic.Text = "";
                cbTestHeaderMode.Text = "";
                cbTestHeaderMode.IsEnabled = false;
                btnTestHeaderStart.IsEnabled = false;
            }
        }

        private void cbTestHeaderSubtopic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbTestHeaderMode.IsEnabled = true;
        }

        private void cbTestHeaderMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnTestHeaderStart.IsEnabled = true;
        }

        private void btnTestHeaderStart_Click(object sender, RoutedEventArgs e)
        {
            if(DataBase.GetWords(cbTestHeaderTopic.SelectedItem.ToString(), cbTestHeaderSubtopic.SelectedItem.ToString()).Count > 3)
            {
                StartTest();
                ShowTestGrid();
                ResetTestHeader();
            }
            else
            {
                MessageBox.Show("Test should contain at least 4 words. You can add words in current subtopic or choose other");
            }
        }

        private void StartTest()
        {
            List<(string left, string right)> allWords =
                DataBase.GetWords(cbTestHeaderTopic.SelectedItem.ToString(), cbTestHeaderSubtopic.SelectedItem.ToString());

            SetProgressBarsMaxValue(allWords.Count);

            string testMode = cbTestHeaderMode.SelectedItem.ToString();
            if (testMode == "Inverse")
            {
                InverseWords();
            }

            int[] indexes = GetRandomUniqueIndexes(0, allWords.Count - 1, allWords.Count);
            int currentIndex = 0;

            string[] answers = new string[allWords.Count];

            int rightAnswersCount = 0;
            int wrongAnswersCount = 0;
            int noAnswersCount = allWords.Count;

            SetCurrentWords();

            btnTestTestNext.Click += new RoutedEventHandler(btnTestTestNext_Click);
            btnTestTestFinish.Click += new RoutedEventHandler(btnTestTestFinish_Click);

            #region Methods

            void btnTestTestNext_Click(object sender, RoutedEventArgs e)
            {
                RadioButton checkedRadioButton =
                    grdTestTest.Children.
                        OfType<RadioButton>().
                        Where(rb => rb.IsChecked == true).
                        FirstOrDefault();

                CheckAnswer(checkedRadioButton);

                currentIndex++;

                if (currentIndex == indexes.Length)
                {
                    FinishTest();
                }
                else
                {
                    SetCurrentWords();
                }

                ResetRadioButton(checkedRadioButton);
            }

            void btnTestTestFinish_Click(object sender, RoutedEventArgs e)
            {
                FinishTest();
            }

            string[] GetWordSet()
            {
                Random rnd = new Random();

                string[] words = new string[4];

                int rightWordIndex = rnd.Next(4);
                int[] tempIndexes = GetRandomUniqueIndexes(0, allWords.Count - 1, 4);
                int currentTempIndex = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (i == rightWordIndex)
                    {
                        words[i] = allWords[indexes[currentIndex]].right;
                    }
                    else
                    {
                        if (tempIndexes[currentTempIndex] != indexes[currentIndex])
                        {
                            words[i] = allWords[tempIndexes[currentTempIndex]].right;
                        }
                        else
                        {
                            words[i] = allWords[tempIndexes[3]].right;
                        }
                        currentTempIndex++;
                    }
                }

                return words;
            }

            void FinishTest()
            {
                ShowTestResultsGrid();
                ShowAnswersRatio();
                ShowAnswersResult();

                btnTestTestNext.Click -= btnTestTestNext_Click;
                btnTestTestFinish.Click -= btnTestTestFinish_Click;
            }

            void SetProgressBarsMaxValue(int value)
            {
                prbTestResultRightAnswers.Maximum = value;
                prbTestResultWrongAnswers.Maximum = value;
                prbTestResultUnknown.Maximum = value;
            }

            void SetCurrentWords()
            {
                tbTestTestCurrentWordNumber.Text = $"{currentIndex + 1} / {allWords.Count}";

                tbTestTestWord.Text = allWords[indexes[currentIndex]].left;

                string[] words = GetWordSet();

                rbtnTestTest1.Content = words[0];
                rbtnTestTest2.Content = words[1];
                rbtnTestTest3.Content = words[2];
                rbtnTestTest4.Content = words[3];
            }

            void InverseWords()
            {
                for (int i = 0; i < allWords.Count; i++)
                {
                    (string left, string right) temp = (allWords[i].left, allWords[i].right);
                    Swap(ref temp.left, ref temp.right);
                    allWords[i] = temp;
                }
            }

            void ShowAnswersRatio()
            {
                tbTestResultRightAnswers.Text = rightAnswersCount.ToString();
                tbTestResultWrongAnswers.Text = wrongAnswersCount.ToString();
                tbTestResultNoAnswer.Text = noAnswersCount.ToString();

                prbTestResultRightAnswers.Value = rightAnswersCount;
                prbTestResultWrongAnswers.Value = wrongAnswersCount;
                prbTestResultUnknown.Value = noAnswersCount;
            }

            void CheckAnswer(RadioButton radioButton)
            {
                if (radioButton != null &&
                    radioButton.Content.ToString() == allWords[indexes[currentIndex]].right)
                {
                    rightAnswersCount++;
                    noAnswersCount--;
                    answers[currentIndex] = radioButton.Content.ToString();
                }
                else if (radioButton != null)
                {
                    wrongAnswersCount++;
                    noAnswersCount--;
                    answers[currentIndex] = radioButton.Content.ToString();
                }
            }

            void ResetRadioButton(RadioButton radioButton)
            {
                if (radioButton != null)
                {
                    radioButton.IsChecked = false;
                }
            }

            void AppendColorText(string text, Brush color)
            {
                TextRange range =
                            new TextRange(
                                rtbTestResultWords.Document.ContentEnd,
                                rtbTestResultWords.Document.ContentEnd);
                range.Text = text;
                range.ApplyPropertyValue(ForegroundProperty, color);
            }

            void ShowAnswersResult()
            {
                TextRange range = new TextRange(
                    rtbTestResultWords.Document.ContentStart,
                    rtbTestResultWords.Document.ContentEnd);
                range.Text = "\r\n";

                for (int i = 0; i < allWords.Count; i++)
                {
                    if (answers[i] == allWords[indexes[i]].right)
                    {
                        AppendColorText("right\n", colorTestGood.Fill);

                        rtbTestResultWords.
                            AppendText($"{allWords[indexes[i]].left} - {allWords[indexes[i]].right}\n\n");
                    }
                    else if (answers[i] == null)
                    {
                        AppendColorText("no answer\n", colorTestUnknown.Fill);

                        rtbTestResultWords.
                            AppendText($"{allWords[indexes[i]].left} - {allWords[indexes[i]].right}\n\n");
                    }
                    else
                    {
                        AppendColorText("wrong\n", colorTestFail.Fill);

                        rtbTestResultWords.AppendText($"word: {allWords[indexes[i]].left}\n");
                        rtbTestResultWords.AppendText($"your answer: {answers[i]}\n");
                        rtbTestResultWords.AppendText($"right answer: {allWords[indexes[i]].right}\n\n");
                    }
                }
            }

            #endregion
        }

        private void ShowTestGrid()
        {
            grdTestTest.Visibility = Visibility.Visible;
            grdTestHeader.Visibility = Visibility.Hidden;
            grdTestResult.Visibility = Visibility.Hidden;
        }

        private void ShowTestResultsGrid()
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
    }
}
