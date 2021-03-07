using System.Windows;

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
            int[] allIndexes = new int[maxValue - minValue];

            for (int i = 0, index = minValue; i < allIndexes.Length; i++, index++)
            {
                allIndexes[i] = index;
            }
        }
    }
}