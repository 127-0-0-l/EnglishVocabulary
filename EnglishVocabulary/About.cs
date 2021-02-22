using System;
using System.IO;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        /// <summary>
        /// Load text from "About.txt" to about section.
        /// </summary>
        private void LoadAbout()
        {
            string path = Environment.CurrentDirectory + @"\..\..\Assets\About.txt";

            using (StreamReader file = new StreamReader(path))
            {
                rtbHelpText.AppendText(file.ReadToEnd());
            }
        }
    }
}
