using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath);

            int counter = 0;

            string line = reader.ReadLine();
            while (line != null)
            {
                if (counter % 2 == 1)
                {
                    writer.WriteLine(line);
                }
                counter++;
                line = reader.ReadLine();
            }
        }
    }
}
