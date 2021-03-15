﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

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
            if(DataBase.GetWords(cbTestHeaderSubtopic.SelectedItem.ToString()).Count > 3)
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

            if (cbTestHeaderMode.SelectedItem.ToString() == "Inverse")
            {
                for (int i = 0; i < allWords.Count; i++)
                {
                    (string left, string right) temp = (allWords[i].left, allWords[i].right);
                    Swap(ref temp.left, ref temp.right);
                    allWords[i] = temp;
                }
            }

            int[] indexes = GetRandomUniqueIndexes(0, allWords.Count - 1, allWords.Count - 1);
            int currentIndex = 0;

            int rightAnswersCount = 0;
            int wrongAnswersCount = 0;
            int noAnswersCount = 0;

            SetCurrentWords();

            btnTestTestNext.Click += (s, a) =>
            {
                RadioButton checkedRadioButton =
                    grdTestTest.Children.
                        OfType<RadioButton>().
                        Where(rb => rb.IsChecked == true).
                        FirstOrDefault();

                if(checkedRadioButton == null)
                {
                    noAnswersCount++;
                }
                else if(checkedRadioButton.Content.ToString() == allWords[indexes[currentIndex]].right)
                {
                    rightAnswersCount++;
                }
                else
                {
                    wrongAnswersCount++;
                }

                currentIndex++;

                if(currentIndex == indexes.Length)
                {
                    FinishTest();
                }
                else
                {
                    SetCurrentWords();
                    checkedRadioButton.IsChecked = false;
                }
            };

            btnTestTestFinish.Click += (s, a) =>
            {
                FinishTest();
            };

            void SetCurrentWords()
            {
                tbTestTestWord.Text = allWords[indexes[currentIndex]].left;

                string[] words = GetWordSet();

                rbtnTestTest1.Content = words[0];
                rbtnTestTest2.Content = words[1];
                rbtnTestTest3.Content = words[2];
                rbtnTestTest4.Content = words[3];
            }
            
            string[] GetWordSet()
            {
                string[] words = new string[4];
                Random rnd = new Random();

                int rightWordIndex = rnd.Next(4);
                int[] tempIndexes = GetRandomUniqueIndexes(0, allWords.Count - 1, 4);
                int currentTempIndex = 0;

                for (int i = 0; i < 4; i++)
                {
                    if(i == rightWordIndex)
                    {
                        words[i] = allWords[indexes[currentIndex]].right;
                    }
                    else
                    {
                        if(tempIndexes[currentTempIndex] != currentIndex)
                        {
                            words[i] = allWords[tempIndexes[currentTempIndex]].right;
                        }
                        else
                        {
                            words[i] = allWords[3].right;
                        }
                        currentTempIndex++;
                    }
                }

                return words;
            }

            void FinishTest()
            {
                grdTestTest.Visibility = Visibility.Hidden;
                grdTestHeader.Visibility = Visibility.Visible;
                grdTestResult.Visibility = Visibility.Visible;

                tbTestResultRightAnswers.Text = rightAnswersCount.ToString();
                tbTestResultWrongAnswers.Text = wrongAnswersCount.ToString();
                tbTestResultNoAnswer.Text = noAnswersCount.ToString();
            }
        }
    }
}
