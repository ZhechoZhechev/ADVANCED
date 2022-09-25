using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using StreamReader readFirst = new StreamReader(firstInputFilePath);
            using StreamReader readSecond = new StreamReader(secondInputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);

            string lineOne = readFirst.ReadLine();
            string linetwo = readSecond.ReadLine();

            while (lineOne != null && linetwo != null )
            {
                writer.WriteLine(lineOne);
                writer.WriteLine(linetwo);

                lineOne = readFirst.ReadLine();
                linetwo = readSecond.ReadLine();
            }
        }
    }
}
