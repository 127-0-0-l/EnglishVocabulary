using System.Windows;
using System;

namespace EnglishVocabulary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActivateCompanyLogo();
            LoadHelp();
            LoadAbout();
        }

        private int[] GetRandomUniqueIndexes(int minValue, int maxValue, int count)
        {
            int allValuesCount = maxValue - minValue + 1;

            if (count > allValuesCount)
            {
                count = allValuesCount;
            }

            int[] allIndexes = new int[allValuesCount];

            for (int i = 0, ind = minValue; i < allIndexes.Length; i++, ind++)
            {
                allIndexes[i] = ind;
            }

            int[] resultIndexes = new int[count];

            Random rnd = new Random();
            int maxIndex = allIndexes.Length - 1;
            int index;
            for (int i = 0; i < resultIndexes.Length; i++)
            {
                index = rnd.Next(maxIndex + 1);
                resultIndexes[i] = allIndexes[index];

                allIndexes[index] = allIndexes[maxIndex];
                maxIndex--;
            }

            return resultIndexes;
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private void cbDeleteTopicTopic_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void btnDeleteTopicDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbDeleteTopicSubtopic_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}