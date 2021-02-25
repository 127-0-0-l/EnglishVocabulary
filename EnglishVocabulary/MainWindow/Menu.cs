using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        /// <summary>
        /// Show Test section.
        /// </summary>
        private void btnMenuTest_Click(object sender, RoutedEventArgs e)
        {
            SetActiveSection(grdTest);
        }

        /// <summary>
        /// Show AddTopic section.
        /// </summary>
        private void btnMenuAddTopic_Click(object sender, RoutedEventArgs e)
        {
            SetActiveSection(grdAddTopic);
        }

        /// <summary>
        /// Show EditTopic section.
        /// </summary>
        private void btnMenuEditTopic_Click(object sender, RoutedEventArgs e)
        {
            SetActiveSection(grdEditTopic);
        }

        /// <summary>
        /// Show DeleteTopic section.
        /// </summary>
        private void btnMenuDeleteTopic_Click(object sender, RoutedEventArgs e)
        {
            SetActiveSection(grdDeleteTopic);
        }

        /// <summary>
        /// Show ColorTheme section.
        /// </summary>
        private void btnMenuColorTheme_Click(object sender, RoutedEventArgs e)
        {
            SetActiveSection(grdColorTheme);
        }

        /// <summary>
        /// Show Help section.
        /// </summary>
        private void btnMenuHelp_Click(object sender, RoutedEventArgs e)
        {
            SetActiveSection(grdHelp);
        }

        /// <summary>
        /// Show About section.
        /// </summary>
        private void btnMenuAbout_Click(object sender, RoutedEventArgs e)
        {
            SetActiveSection(grdAbout);
        }

        /// <summary>
        /// Constantly changing color of company logo in menu grid.
        /// </summary>
        private void ActivateCompanyLogo()
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 0, 0, 50);

            byte maxValue = 255;
            byte minValue = 75;
            byte speed = 4;
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

        /// <summary>
        /// Set active section (show it).
        /// </summary>
        private void SetActiveSection(Grid grdSection)
        {
            grdTest.Visibility = Visibility.Hidden;
            grdAddTopic.Visibility = Visibility.Hidden;
            grdEditTopic.Visibility = Visibility.Hidden;
            grdDeleteTopic.Visibility = Visibility.Hidden;
            grdColorTheme.Visibility = Visibility.Hidden;
            grdHelp.Visibility = Visibility.Hidden;
            grdAbout.Visibility = Visibility.Hidden;

            grdSection.Visibility = Visibility.Visible;
        }
    }
}
