using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextJustificationApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FullJustify(new string[] { "This", "is", "an", "example", "of", "text", "justification." }, 16);
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
            Console.ReadKey();
        }

        public static IList<string> FullJustify(string[] words,
            int maxWidth)
        {
            IList<string> result = new List<string>();
            int left = 0;

            while (left < words.Length)
            {
                int right = FindRight(left, words.ToList(), maxWidth);
                result.Add(Justfiy(left, right, words, maxWidth));
                left = right + 1;
            }

            return result;
        }

        public static int FindRight(int left, List<string> words, int maxWidth)
        {
            int right = left;
            int currentWordSize = words[right].Length;
            right++;

            while (right < words.Count && (currentWordSize + 1 + words[right].Length) <= maxWidth)
            {
                currentWordSize += 1 + words[right].Length;
                right++;
            }

            return right - 1;
        }

        public static string Justfiy(int left, int right, string[] words, int maxWidth)
        {
            if (right - left == 0)
            {
                return PadResult(words[left], maxWidth);
            }

            bool isLastLine = (right == words.Length - 1);
            int numSpaces = right - left;
            int totalSpace = maxWidth - WordsLength(left, right, words);

            string space = isLastLine ? " " : Blank(totalSpace / numSpaces);
            int remainder = isLastLine ? 0 : totalSpace % numSpaces;

            StringBuilder result = new StringBuilder();
            for (int i = left; i <= right; i++)
            {
                result.Append(words[i])
                    .Append(space)
                    .Append(remainder-- > 0 ? " " : "");
            }

            return PadResult(result.ToString().Trim(), maxWidth);
        }

        public static int WordsLength(int left, int right, string[] words)
        {
            int wordsLength = 0;
            for (int i = left; i <= right; i++)
            {
                wordsLength += words[i].Length;
            }
            return wordsLength;
        }

        public static string PadResult(string result, int maxWidth)
        {
            return result + Blank(maxWidth - result.Length);
        }

        public static string Blank(int length)
        {
            return new string(new char[length]).Replace('\0', ' ');
        }
    }
}
