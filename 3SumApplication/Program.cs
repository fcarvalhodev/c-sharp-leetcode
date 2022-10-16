using System;
using System.Collections.Generic;
using System.Linq;

namespace _3SumApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            foreach (var i in result)
            {
                if (i.Count > 0)
                {
                    foreach (var value in i)
                    {
                        Console.WriteLine(value);
                    }
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadKey();
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<int> arr = nums.OfType<int>().ToList();
            IList<IList<int>> result = new List<IList<int>>();

            arr.Sort();
            int k = arr.Count - 1;

            for (int i = 0; i < arr.Count - 2; i++)
            {
                int j = i + 1;

                if ((i != j && i != k && j != k))
                {
                    if ((arr[i] + arr[j]) + arr[k] == 0)
                        result.Add(new List<int> { arr[i], arr[j], arr[k] });
                }
                k--;
            }

            return result;
        }
    }
}
