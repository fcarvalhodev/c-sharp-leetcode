using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integerValues = { 54, 26, 93, 17, 77, 31, 44, 55, 20 };
            Console.WriteLine("Before Quick Sort");
            Console.WriteLine(string.Join(" | ", integerValues));
            Sort(integerValues);
            Console.WriteLine("After Quick Sort");
            Console.WriteLine(string.Join(" | ", integerValues));
            Console.ReadKey();
        }

        public static void Sort<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
        }

        private static T[] Sort<T>(T[] array, int lower, int upper) where T : IComparable
        {
            if (lower < upper)
            {
                int p = Partition(array, lower, upper);
                Sort(array, lower, p);
                Sort(array, p + 1, upper);
            }

            return array;
        }

        private static int Partition<T>(T[] array, int lower, int upper) where T : IComparable
        {
            int i = lower;
            int j = upper;
            T pivot = array[lower];

            do
            {
                while (array[i].CompareTo(pivot) < 0)//se x < y = -1
                {
                    i++;
                }
                while (array[j].CompareTo(pivot) > 0)//se x > y = 1
                {
                    j--;
                }

                if (i >= j)
                    break;

                Swap(array, i, j);

            } while (i <= j);

            return j;
        }

        public static void Swap<T>(T[] array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
