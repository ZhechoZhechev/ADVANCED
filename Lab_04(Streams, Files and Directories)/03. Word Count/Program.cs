using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var dictWordAppear = new Dictionary<string, int>();

            using var readerWords = new StreamReader(wordsFilePath);

            using var readerText = new StreamReader(textFilePath);

            using var writerInActualResult = new StreamWriter(outputFilePath);

            //using var writerInExpectedResult = new StreamWriter("expectedResult.txt")

            string[] wordsArray = readerWords.ReadToEnd().ToLower().Split();
            while (!readerText.EndOfStream)
            {
                var lineArray = readerText.ReadLine().ToLower().Split(new char[] { ',', '.', '!', '?', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var wordInWordsArray in wordsArray)
                {
                    foreach (var wordInLineArray in lineArray)
                    {
                        if (string.Equals(wordInWordsArray, wordInLineArray))
                        {
                            if (!dictWordAppear.ContainsKey(wordInWordsArray))
                            {
                                dictWordAppear[wordInWordsArray] = 0;
                            }

                            dictWordAppear[wordInWordsArray]++;
                        }
                    }
                }


                //foreach (var (word, appear) in dictWordAppear)
                //{
                //    writerInActualResult.WriteLine($"{word}-{appear}");
                //}

               
            }

            var sortedDict = dictWordAppear.OrderByDescending(x => x.Value);
            foreach (var word in sortedDict)
            {
                writerInActualResult.WriteLine($"{word.Key}-{word.Value}");
            }

        }
    }
}
