using System;

namespace BubbleSortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            Console.WriteLine("Before Bubble Sort");
            Console.WriteLine(string.Join(" | ", integerValues));
            Sort(integerValues);
            Console.WriteLine("After Bubble Sort");
            Console.WriteLine(string.Join(" | ", integerValues));
            Console.ReadKey();
        }

        public static void Sort<T>(T[] array) where T : IComparable
        {
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array.Length-1; j++)
                {
                    if(array[j].CompareTo(array[j+1]) > 0)
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        public static void Swap<T>(T[] array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
