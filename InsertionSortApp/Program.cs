using System;

namespace InsertionSortApp
{
    public class Program
    {
        static void Main(string[] args)
        {       
            int[] integerValues = { 54, 26, 93, 17, 77, 31, 44, 55, 20 };
            Console.WriteLine("Before Insertion Sort");
            Console.WriteLine(string.Join(" | ", integerValues));
            Sort(integerValues);
            Console.WriteLine("After Insertion Sort");
            Console.WriteLine(string.Join(" | ", integerValues));
            Console.ReadKey();
        }

        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;

                while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
                {
                    Swap(array, j, j - 1);
                    j--;
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
