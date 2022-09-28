namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            //string inputPath = @"E:\Call of Duty Modern Warfare";
            string outputPath = @$"{Console.ReadLine()}";
            //string outputPath = @"D:\test_new";
            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);

            string[] fileInDir = Directory.GetFiles(inputPath);

            foreach (var srcPath in fileInDir)
            {
                //Copy the file from sourcepath and place into mentioned target path, 
                //Overwrite the file if same file is exist in target path
                File.Copy(srcPath, srcPath.Replace(inputPath, outputPath), true);
            }
        }
    }
}
