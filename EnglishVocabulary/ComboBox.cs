using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        public void ActivateComboBoxes()
        {
            MessageBox.Show(this.GetChildren().OfType<ComboBox>().Count().ToString());
            //foreach (ComboBox cb in this.GetChildren().OfType<ComboBox>())
            //{

            //}
        }
    }
}
