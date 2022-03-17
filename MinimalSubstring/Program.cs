using System;
using System.Collections.Generic;

namespace MinimalSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = solution("dddd");
            Console.WriteLine(result);
        }

        static int solution(string S)
        {
            int result = (string.IsNullOrEmpty(S) ? 0 : 1);
            char[] chars = S.ToCharArray();

            HashSet<char> lettersArr = new HashSet<char>();

            for (int i = 0; i < chars.Length; i++)
            {
                if (lettersArr.Contains(chars[i]))
                {
                    lettersArr.Clear();
                    result++;
                }
                lettersArr.Add(chars[i]);
            }

            return result;
        }
    }
}
