using System;

namespace EvenWordApplication
{
    class Program
    {
        private static int deletions = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = solution("axxaxa");
        }



        public static int solution(string S)
        {
            var counter = new int[26];
            for (int i = 0; i < S.Length; i++)
                counter[S[i] - 'a']++;

            var numRemove = 0;
            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] % 2 == 1)
                    numRemove++;
            }

            return numRemove;
        }
    }
}
