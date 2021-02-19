using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            ActivateComboBoxes();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            grdMenuItemAbout.MouseDown += (s, a) =>
            {
                grdMenuItemAbout.Background = rsrcClrHeaderBackground.Fill;
            };
            grdMenuItemAbout.MouseUp += (s, a) =>
            {
                grdMenuItemAbout.Background = rsrcClrMenuButtonEnter.Fill;
            };
            grdMenuItemAbout.MouseEnter += (s, a) =>
            {
                grdMenuItemAbout.Background = rsrcClrMenuButtonEnter.Fill;
            };
            grdMenuItemAbout.MouseLeave += (s, a) =>
            {
                grdMenuItemAbout.Background = rsrcClrMenuButton.Fill;
            };










            //DataBaseAccess.CreateTopic(new Topic());

            //foreach (var item in DataBaseAccess.GetData())
            //{
            //    MessageBox.Show(item);
            //}
        }
    }
}
