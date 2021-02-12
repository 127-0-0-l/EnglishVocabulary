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

            grdMenuItemTest.MouseEnter += (s, e) =>
            {
                grdMenuItemTest.Background = new SolidColorBrush(Color.FromRgb(0, 100, 0));
            };
            grdMenuItemTest.MouseLeave += (s, e) =>
            {
                grdMenuItemTest.Background = new SolidColorBrush(Color.FromRgb(100, 0, 0));
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DataBaseAccess.CreateTopic(new Topic());

            foreach (var item in DataBaseAccess.GetData())
            {
                //MessageBox.Show(item);
            }
        }
    }
}
