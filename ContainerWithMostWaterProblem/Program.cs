using System;

namespace ContainerWithMostWaterProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int MaxArea(int[] height)
        {
            int maxarea = 0;
            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                int width = right - left;
                maxarea = Math.Max(maxarea, Math.Min(height[left], height[right]) * width);
                if (height[left] <= height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return maxarea;
        }
    }
}
