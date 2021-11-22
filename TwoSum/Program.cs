using System;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = TwoSum(new int[] { 3,2,4 }, 6);
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            bool found = false;

            for (int j = 0; j < nums.Length; j++)
            {
                if (found)
                    break;

                for (int k = 0; k < nums.Length; k++)
                {
                    if (nums[j] + nums[k] == target && j != k)
                    {
                        result[0] = j;
                        result[1] = k;
                        found = true;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
