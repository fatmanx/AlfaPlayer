using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlfaPlayer2
{
    public class Library
    {

        private Library()
        {
        }

        public static Library Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Library instance = new Library();
        }

        public void RefreshLibrary()
        {
            files = null;
            GetFiles();
        }

        string[] files = null;
        public string[] extensions = { ".mp3", ".flac", ".wma", ".wav", ".aac" };

        public string[] GetFiles()
        {

            DirectoryInfo root = null;
            try
            {
                root = new DirectoryInfo(Properties.Settings.Default.RootFolder);
            }
            catch { }

            string SourceFolder = root.FullName;
            string Filter = "*" + string.Join("|*", extensions);

            System.IO.SearchOption searchOption = SearchOption.AllDirectories;
            if (files != null)
            {
                return files;
            }

            // ArrayList will hold all file names
            ArrayList alFiles = new ArrayList();

            // Create an array of filter string
            string[] MultipleFilters = Filter.Split('|');

            // for each filter find mathing file names
            foreach (string FileFilter in MultipleFilters)
            {
                // add found file names to array list
                alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption));
            }
            alFiles.Sort();

            // returns string array of relevant file names
            files = (string[])alFiles.ToArray(typeof(string));
            return files;
        }



    }
}
