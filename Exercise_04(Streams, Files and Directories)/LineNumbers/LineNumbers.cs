namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder formatedText = new StringBuilder();
            string[] stringOfLines = File.ReadAllLines(inputFilePath);
            int linesCount = 1;
            
            for (int i = 0; i < stringOfLines.Length; i++)
            {
                int lettersCount = stringOfLines[i].Count(c => char.IsLetter(c));
                int punctuationCount = stringOfLines[i].Count(x => char.IsPunctuation(x));
                
                formatedText.AppendLine($"Line {linesCount++}: {stringOfLines[i]} ({lettersCount})({punctuationCount})");
            }

            File.WriteAllText(outputFilePath, formatedText.ToString());
        }
    }
}
