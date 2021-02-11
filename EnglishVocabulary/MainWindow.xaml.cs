using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            try
            {
                VocabularyDBContext dBContext = new VocabularyDBContext();
                //dBContext.Topics.RemoveRange(dBContext.Topics);
                dBContext.Topics.Add(new Vocabulary());
                //dBContext.Topics.Add(new Topics());
                dBContext.SaveChanges();

                foreach (var item in dBContext.Topics)
                {
                    MessageBox.Show(item.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
