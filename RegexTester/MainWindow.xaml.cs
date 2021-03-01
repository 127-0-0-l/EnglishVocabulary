using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RegexTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tbRegexExpr_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindMatches();
        }

        private void rtbText_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindMatches();
        }

        private void FindMatches()
        {
            try
            {
                rtbMatches.Document.Blocks.Clear();

                MatchCollection matches = new Regex(tbRegexExpr.Text).
                    Matches(new TextRange(
                        rtbText.Document.ContentStart,
                        rtbText.Document.ContentEnd).Text);

                tbResult.Text = matches.Count.ToString();

                rtbMatches.AppendText(Environment.NewLine);
                foreach (var item in matches)
                {
                    rtbMatches.AppendText(item.ToString() + Environment.NewLine);
                }
            }
            catch
            {
                tbResult.Text = "error";
            }
        }
    }
}
