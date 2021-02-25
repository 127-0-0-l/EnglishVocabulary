using System.Windows.Input;
using System.Windows;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        /// <summary>
        /// Move window.
        /// </summary>
        private void grdDragMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /// <summary>
        /// Change button color, when mouse enter.
        /// </summary>
        private void rctBtnMinimize_MouseEnter(object sender, MouseEventArgs e)
        {
            rctBtnMinimize.Fill = colorHeaderButtonEnter.Fill;
        }

        /// <summary>
        /// Change button color, when mouse leave.
        /// </summary>
        private void rctBtnMinimize_MouseLeave(object sender, MouseEventArgs e)
        {
            rctBtnMinimize.Fill = colorHeaderButton.Fill;
        }

        /// <summary>
        /// Change button color, when mouse down.
        /// </summary>
        private void rctBtnMinimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rctBtnMinimize.Fill = colorHeaderButtonClick.Fill;
        }

        /// <summary>
        /// Change button color, when mouse up
        /// and minimize window.
        /// </summary>
        private void rctBtnMinimize_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rctBtnMinimize.Fill = colorHeaderButton.Fill;
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Change button color, when mouse enter.
        /// </summary>
        private void rctBtnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            rctBtnClose.Fill = colorHeaderButtonEnter.Fill;
        }

        /// <summary>
        /// Change button color, when mouse leave.
        /// </summary>
        private void rctBtnClose_MouseLeave(object sender, MouseEventArgs e)
        {
            rctBtnClose.Fill = colorHeaderButton.Fill;
        }

        /// <summary>
        /// Change button color, when mouse down.
        /// </summary>
        private void rctBtnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rctBtnClose.Fill = colorHeaderButtonClick.Fill;
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void rctBtnClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
