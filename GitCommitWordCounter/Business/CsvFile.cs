using GitCommitWordCounter.Model;
using GitCommitWordCounter.Shared;
using System;
using System.Collections.Generic;
using System.IO;

namespace GitCommitWordCounter.Business
{
    public class CsvFile : IFile
    {
        private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string savePath = Path.Combine(desktopPath, "export.csv");

        public void Export(List<WordCount> wordCountList)
        {
            using (var w = new StreamWriter(savePath))
            {
                foreach (var c in wordCountList)
                { 
                    string line = string.Format("{0},{1}", c.Word, c.Count);
                    w.WriteLine(line);
                    w.Flush();
                }
            }
        }
    }
}
