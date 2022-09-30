using System;

namespace SumOfDigits
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = solution(1234);
            Console.WriteLine(result);
        }

        static int sumOfDigits(int N)
        {
            int sum = 0;
            while (N != 0)
            {
                sum += N % 10;
                N /= 10;
            }
            return sum;
        }

        static int solution(int N)
        {
            int result = N + 1;
            int sumOfNDoubled = sumOfDigits(N) * 2;
            while (true)
            {
                if (sumOfDigits(result) == sumOfNDoubled)
                {
                    return result;
                }
                result++;
            }
        }
    }
}
