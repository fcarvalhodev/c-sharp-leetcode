using System;

namespace MultiplicationTableApp
{
    class Program
    {
        //TODO - Create a better way to show the whole table.
        static void Main(string[] args)
        {
            Console.WriteLine("Example of a multiplication table using multidimensional array");
            var result = BuildTable(new int[10, 10]);
            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                    Console.WriteLine("{0,4}", result[i, j]);

            Console.WriteLine("");
        }

        private static int[,] BuildTable(int[,] tableSize) 
        {
            int[,] result = new int[10,10];

            for (int j = 0; j < tableSize.GetLength(0); j++)
                for (int k = 0; k < tableSize.GetLength(1); k++)
                    result[j, k] = (j + 1) * (k + 1);

            return result;
        }
    }
}
