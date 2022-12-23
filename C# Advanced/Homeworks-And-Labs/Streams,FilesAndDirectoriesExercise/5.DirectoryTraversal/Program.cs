using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var groupedFiles = new Dictionary<string, Dictionary<string, double>>();

            // "." - returns all files
            // "*.txt" - returns all "txt" files

            string[] allFiles = Directory.GetFiles(".");

            foreach (var file in allFiles)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!groupedFiles.ContainsKey(fileInfo.Extension))
                {
                    groupedFiles.Add(fileInfo.Extension, new Dictionary<string, double>());
                }

                double size = (double)fileInfo.Length / 1024;
                groupedFiles[fileInfo.Extension].Add(fileInfo.Name, size);
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";

            var sortedFiles = groupedFiles
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);

            foreach (var kvp in sortedFiles)
            {
                File.AppendAllText(path, kvp.Key + Environment.NewLine);

                foreach (var file in kvp.Value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(path, $"--{file.Key} - {file.Value:f3}kb" + Environment.NewLine);
                }
            }
        }
    }
}
