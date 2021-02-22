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
        /// Change button color when mouse enter.
        /// </summary>
        private void grdMenuItemTest_MouseEnter(object sender, MouseEventArgs e)
        {
            grdMenuItemTest.Background = colorButtonEnter.Fill;
        }

        /// <summary>
        /// Change button color when mouse leave.
        /// </summary>
        private void grdMenuItemTest_MouseLeave(object sender, MouseEventArgs e)
        {
            grdMenuItemTest.Background = colorButton.Fill;
        }

        /// <summary>
        /// Change button color when mouse down.
        /// </summary>
        private void grdMenuItemTest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemTest.Background = colorButtonClick.Fill;
        }

        /// <summary>
        /// Change button color when mouse up
        /// and show appropriate section.
        /// </summary>
        private void grdMenuItemTest_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemTest.Background = colorButtonEnter.Fill;
            SetActiveSection(grdTest);
        }

        /// <summary>
        /// Change button color when mouse enter.
        /// </summary>
        private void grdMenuItemAddTopic_MouseEnter(object sender, MouseEventArgs e)
        {
            grdMenuItemAddTopic.Background = colorButtonEnter.Fill;
        }

        /// <summary>
        /// Change button color when mouse leave.
        /// </summary>
        private void grdMenuItemAddTopic_MouseLeave(object sender, MouseEventArgs e)
        {
            grdMenuItemAddTopic.Background = colorButton.Fill;
        }

        /// <summary>
        /// Change button color when mouse down.
        /// </summary>
        private void grdMenuItemAddTopic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemAddTopic.Background = colorButtonClick.Fill;
        }

        /// <summary>
        /// Change button color when mouse up
        /// and show appropriate section.
        /// </summary>
        private void grdMenuItemAddTopic_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemAddTopic.Background = colorButtonEnter.Fill;
            SetActiveSection(grdAddTopic);
        }

        /// <summary>
        /// Change button color when mouse enter.
        /// </summary>
        private void grdMenuItemEditTopic_MouseEnter(object sender, MouseEventArgs e)
        {
            grdMenuItemEditTopic.Background = colorButtonEnter.Fill;
        }

        /// <summary>
        /// Change button color when mouse leave.
        /// </summary>
        private void grdMenuItemEditTopic_MouseLeave(object sender, MouseEventArgs e)
        {
            grdMenuItemEditTopic.Background = colorButton.Fill;
        }

        /// <summary>
        /// Change button color when mouse down.
        /// </summary>
        private void grdMenuItemEditTopic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemEditTopic.Background = colorButtonClick.Fill;
        }

        /// <summary>
        /// Change button color when mouse up
        /// and show appropriate section.
        /// </summary>
        private void grdMenuItemEditTopic_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemEditTopic.Background = colorButtonEnter.Fill;
            SetActiveSection(grdEditTopic);
        }

        /// <summary>
        /// Change button color when mouse enter.
        /// </summary>
        private void grdMenuItemDeleteTopic_MouseEnter(object sender, MouseEventArgs e)
        {
            grdMenuItemDeleteTopic.Background = colorButtonEnter.Fill;
        }

        /// <summary>
        /// Change button color when mouse leave.
        /// </summary>
        private void grdMenuItemDeleteTopic_MouseLeave(object sender, MouseEventArgs e)
        {
            grdMenuItemDeleteTopic.Background = colorButton.Fill;
        }

        /// <summary>
        /// Change button color when mouse down.
        /// </summary>
        private void grdMenuItemDeleteTopic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemDeleteTopic.Background = colorButtonClick.Fill;
        }

        /// <summary>
        /// Change button color when mouse up
        /// and show appropriate section.
        /// </summary>
        private void grdMenuItemDeleteTopic_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemDeleteTopic.Background = colorButtonEnter.Fill;
            SetActiveSection(grdDeleteTopic);
        }

        /// <summary>
        /// Change button color when mouse enter.
        /// </summary>
        private void grdMenuItemColorTheme_MouseEnter(object sender, MouseEventArgs e)
        {
            grdMenuItemColorTheme.Background = colorButtonEnter.Fill;
        }

        /// <summary>
        /// Change button color when mouse leave.
        /// </summary>
        private void grdMenuItemColorTheme_MouseLeave(object sender, MouseEventArgs e)
        {
            grdMenuItemColorTheme.Background = colorButton.Fill;
        }

        /// <summary>
        /// Change button color when mouse down.
        /// </summary>
        private void grdMenuItemColorTheme_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemColorTheme.Background = colorButtonClick.Fill;
        }

        /// <summary>
        /// Change button color when mouse up
        /// and show appropriate section.
        /// </summary>
        private void grdMenuItemColorTheme_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemColorTheme.Background = colorButtonEnter.Fill;
            SetActiveSection(grdColorTheme);
        }

        /// <summary>
        /// Change button color when mouse enter.
        /// </summary>
        private void grdMenuItemHelp_MouseEnter(object sender, MouseEventArgs e)
        {
            grdMenuItemHelp.Background = colorButtonEnter.Fill;
        }

        /// <summary>
        /// Change button color when mouse leave.
        /// </summary>
        private void grdMenuItemHelp_MouseLeave(object sender, MouseEventArgs e)
        {
            grdMenuItemHelp.Background = colorButton.Fill;
        }

        /// <summary>
        /// Change button color when mouse down.
        /// </summary>
        private void grdMenuItemHelp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemHelp.Background = colorButtonClick.Fill;
        }

        /// <summary>
        /// Change button color when mouse up
        /// and show appropriate section.
        /// </summary>
        private void grdMenuItemHelp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemHelp.Background = colorButtonEnter.Fill;
            SetActiveSection(grdHelp);
        }

        /// <summary>
        /// Change button color when mouse enter.
        /// </summary>
        private void grdMenuItemAbout_MouseEnter(object sender, MouseEventArgs e)
        {
            grdMenuItemAbout.Background = colorButtonEnter.Fill;
        }

        /// <summary>
        /// Change button color when mouse leave.
        /// </summary>
        private void grdMenuItemAbout_MouseLeave(object sender, MouseEventArgs e)
        {
            grdMenuItemAbout.Background = colorButton.Fill;
        }

        /// <summary>
        /// Change button color when mouse down.
        /// </summary>
        private void grdMenuItemAbout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemAbout.Background = colorButtonClick.Fill;
        }

        /// <summary>
        /// Change button color when mouse up
        /// and show appropriate section.
        /// </summary>
        private void grdMenuItemAbout_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdMenuItemAbout.Background = colorButtonEnter.Fill;
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
