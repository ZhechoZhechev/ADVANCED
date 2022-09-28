namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);

            StringBuilder sb = new StringBuilder();

            string line = string.Empty;

            int countLine = 0; 

            while ((line = reader.ReadLine()) != null)
            {
                if (countLine % 2 == 0)
                {
                    line = ReplaceSymbol(line);
                    var reversedLine = line.Split().ToArray().Reverse().ToArray();
                    var output = string.Join(" ", reversedLine);
                    sb.AppendLine(output);
                }
                countLine++;
            }
            return sb.ToString();
        }

        private static string ReplaceSymbol(string line)
        {
            string[] symbolToReplace = { "-", ",", ".", "!", "?" };
            foreach (var symbol in symbolToReplace)
            {
                line = line.Replace(symbol, "@");
            }

            return line;
        }
    }
}
