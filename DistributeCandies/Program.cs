using System;

namespace DistributeCandies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int result = DistributeCandies(new int[] { 1, 1, 2, 2, 3, 3 });
        }

        public static int DistributeCandies(int[] candyType)
        {
            int typeCount = 0;

            if (candyType.Length == 0)
                return 0;

            for (int j = 0; j < candyType.Length; j++)
            {
                bool isUnique = true;

                for (int k = 0; k < j; k++)
                {
                    if (candyType[j] == candyType[k])
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    typeCount++;
                }
            }

            return Math.Min(typeCount, candyType.Length / 2);
        }
    }
}
