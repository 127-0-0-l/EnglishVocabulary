using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        private void grdTestHeaderBtnStart_MouseEnter(object sender, MouseEventArgs e)
        {
            grdTestHeaderBtnStart.Background = colorButtonEnter.Fill;
        }

        private void grdTestHeaderBtnStart_MouseLeave(object sender, MouseEventArgs e)
        {
            grdTestHeaderBtnStart.Background = colorButton.Fill;
        }

        private void grdTestHeaderBtnStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            grdTestHeaderBtnStart.Background = colorButtonClick.Fill;
        }

        private void grdTestHeaderBtnStart_MouseUp(object sender, MouseButtonEventArgs e)
        {
            grdTestHeaderBtnStart.Background = colorButtonEnter.Fill;
            grdTestHeaderBtnStart.Background = colorButtonDisabled.Fill;
            tbTestHeaderBtnStartText.Foreground = colorButtonTextDisabled.Fill;
            grdTestHeaderBtnStart.IsEnabled = false;
        }

        private void grdTestHeaderBtnStart_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (grdTestHeaderBtnStart.IsEnabled == false)
            {
                grdTestHeaderBtnStart.Background = colorButtonDisabled.Fill;
                tbTestHeaderBtnStartText.Foreground = colorButtonTextDisabled.Fill;
            }
            else
            {
                grdTestHeaderBtnStart.Background = colorButton.Fill;
                tbTestHeaderBtnStartText.Foreground = colorButtonText.Fill;
            }
        }
    }
}
