using System;

namespace CompareToApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integerValues = { 1, 2, 3, 4 };
            Console.WriteLine("Before Insertion Sort");
            Console.WriteLine(string.Join(" | ", integerValues));
            Sort(integerValues);
            Console.WriteLine("After Insertion Sort");
            Console.WriteLine(string.Join(" | ", integerValues));
            Console.ReadKey();
        }

        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) < 0)
                    {
                        Swap(array, i, j + 1);
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
