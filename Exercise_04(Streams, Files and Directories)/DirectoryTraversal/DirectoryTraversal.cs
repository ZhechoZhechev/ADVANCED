namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            //string path = @"E:\Call of Duty Modern Warfare";
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> extensionsFiles = new Dictionary<string, List<FileInfo>>();
            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!extensionsFiles.ContainsKey(fileInfo.Extension))
                {
                    extensionsFiles[fileInfo.Extension] = new List<FileInfo>();
                }
                extensionsFiles[fileInfo.Extension].Add(fileInfo);
            }
            var orderedFiles = extensionsFiles.OrderByDescending(x => x.Value.Count);

            StringBuilder sb = new StringBuilder();

            foreach (var file in orderedFiles)
            {
                sb.AppendLine(file.Key);

                var orderedByFileLenght = file.Value.OrderByDescending(c => c.Length);
                foreach (var fileItem in orderedByFileLenght)
                {
                    sb.AppendLine($"--{fileItem.Name} - {(double)fileItem.Length / 1024:f3}kb");
                }
            }
            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(path, textContent);
        }
    }
}
