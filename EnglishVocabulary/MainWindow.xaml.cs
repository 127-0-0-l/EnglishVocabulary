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

            foreach (var item in DataBase.GetWords("SubtopicFirst"))
            {
                rtbAddTopicAllWords.AppendText($"{item.eng} - {item.rus}\n");
            }
        }
    }
}