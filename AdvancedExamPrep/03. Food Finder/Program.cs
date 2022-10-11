using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Food_Finder
{
    class Program
    {
        static void Main()
        {
            char[] vowelsSeq = Console.ReadLine()
                .Split()
                .Select(char.Parse).ToArray();
            char[] consonantsSeq = Console.ReadLine()
                .Split()
                .Select(char.Parse).ToArray();

            Queue<char> vowels = new Queue<char>(vowelsSeq);
            Stack<char> consonants = new Stack<char>(consonantsSeq);

            Dictionary<string, List<char>> wordsCharsCount = new Dictionary<string, List<char>>();
            wordsCharsCount.Add("pear", new List<char>());
            wordsCharsCount.Add("flour", new List<char>());
            wordsCharsCount.Add("pork", new List<char>());
            wordsCharsCount.Add("olive", new List<char>());

            while (consonants.Count > 0)
            {
                char consonant = consonants.Pop();
                var consHits = wordsCharsCount.Where(x => x.Key.Contains(consonant));
                List<string> constHitKeys = consHits.Select(x => x.Key).ToList();
                foreach (var item in constHitKeys)
                {
                    //wordsCharsCount[item] = new List<char>();
                    wordsCharsCount[item].Add(consonant);
                }

                char vowel = vowels.Dequeue();
                var vowelHits = wordsCharsCount.Where(x => x.Key.Contains(vowel));
                List<string> vowelHitKeys = vowelHits.Select(x => x.Key).ToList();
                foreach (var item in vowelHitKeys)
                {
                    //wordsCharsCount[item] = new List<char>();
                    wordsCharsCount[item].Add(vowel);
                }

                vowels.Enqueue(vowel);
            }
            List<string> words = new List<string>();

            foreach (var item in wordsCharsCount)
            {
               var intersections = item.Key.Intersect(item.Value);
                StringBuilder sb = new StringBuilder();
                foreach (var ch in intersections)
                {
                    sb.Append(ch);
                }
                if (sb.ToString() == item.Key)
                {
                    words.Add(item.Key);
                }
            }
            Console.WriteLine($"Words found: {words.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
