using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;

            DirectoryInfo test = new DirectoryInfo(@"..\..\..\Files\TestFolder");
            FileInfo[] files = test.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo file in files)
            {
                sum += file.Length;
            }
            sum = sum / 1024 / 1024;

            File.WriteAllText(@"..\..\..\Files\output.txt", sum.ToString());
        }
    }
}
