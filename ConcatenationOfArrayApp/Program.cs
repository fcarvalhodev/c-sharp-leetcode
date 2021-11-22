using System;
using System.Collections.Generic;

namespace ConcatenationOfArrayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = GetConcatenation(new int[] { 1,2,3});
        }

        public static int[] GetConcatenation(int[] nums)
        {
            List<int> list = new List<int>();
            list.AddRange(nums);
            list.AddRange(nums);

            return list.ToArray();
        }

        public static int[] GetConcatenationWorse(int[] nums)
        {
            int newArrSize = nums.Length * 2;
            int[] arr = new int[newArrSize];
            int start = 0;
            int end = 0;
            do
            {
                if (start == nums.Length)
                    start = 0;

                arr[end] = nums[start];
                start++;
                end++;

            } while (end < newArrSize);

            return arr;
        }
    }
}
