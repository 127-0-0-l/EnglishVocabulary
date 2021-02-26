﻿using System;
using System.IO;

namespace EnglishVocabulary
{
    public partial class MainWindow
    {
        /// <summary>
        /// Load text from "Help.txt" to help section.
        /// </summary>
        private void LoadHelp()
        {
            string path = Environment.CurrentDirectory + @"\..\..\Assets\Help.txt";
            
            using (StreamReader file = new StreamReader(path))
            {
                rtbHelpText.AppendText(file.ReadToEnd());
            }
        }
    }
}