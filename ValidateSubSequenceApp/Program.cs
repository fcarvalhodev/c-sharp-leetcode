using System;
using System.Collections.Generic;

namespace ValidateSubSequenceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var result = IsValidSubsequence(new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 }, new List<int> { 1, 6, -1, 10 });
        }

        public static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            int seqIdx = 0;
            
            for(var j = 0; j < array.Count; j++)
            {
                if (seqIdx == sequence.Count)
                    break;

                if (sequence[seqIdx] == array[j])
                    seqIdx++;
            }
             
            return seqIdx == sequence.Count;
        }
    }
}
