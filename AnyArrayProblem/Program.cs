using System;
using System.Collections.Generic;

namespace AnyArrayProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = solution(8);
            for (var i = 0; i < result.Length; i++)
                Console.WriteLine(result[i]);
            Console.ReadKey();
        }

        private static int[] solution(int N)
        {
            Random rnd = new Random();
            HashSet<int> arr = new HashSet<int>();
            int[] result = new int[N];
            while (arr.Count < N)
            {
                arr.Add(rnd.Next(100));
            }

            int pos = 0;

            foreach(int value in arr)
            {
                result[pos] = value;
                pos++;
            }

            return result;
        }
    }
}
