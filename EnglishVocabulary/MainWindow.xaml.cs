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
using System.Windows.Threading;

namespace EnglishVocabulary
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //ActivateComboBoxes();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GhangeImageColor();

            









            //DataBaseAccess.CreateTopic(new Topic());

            //foreach (var item in DataBaseAccess.GetData())
            //{
            //    MessageBox.Show(item);
            //}
        }

        private void GhangeImageColor()
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 0, 0, 50);

            byte maxValue = 255;
            byte minValue = 75;
            byte speed = 5;
            byte r = maxValue;
            byte g = minValue;
            byte b = minValue;


            t.Tick += (s, a) =>
            {
                if (r == maxValue && g < maxValue && b == minValue)
                {
                    g += speed;
                }
                else if (r > minValue && g == maxValue && b == minValue)
                {
                    r -= speed;
                }
                else if (r == minValue && g == maxValue && b < maxValue)
                {
                    b += speed;
                }
                else if (r == minValue && g > minValue && b == maxValue)
                {
                    g -= speed;
                }
                else if (r < maxValue && g == minValue && b == maxValue)
                {
                    r += speed;
                }
                else if (r == maxValue && g == minValue && b > minValue)
                {
                    b -= speed;
                }

                rctMenuImage.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
            };
            t.Start();
        }
    }
}
