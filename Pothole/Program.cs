using System;

namespace Pothole
{
    internal class Program
    {
        //TODO - Finalizar exercícios
        //Budget da solução inicial = 7
        //reformar 1 x = 2
        //reformar 3 seguidos x = 4
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = solution("...xxx..x....xxx.", 7);
        }

        static int solution(string S, int B)
        {
            char[] roadArr = S.ToCharArray();
            int current = 0;
            int indx = 0;

            return 0;
        }
    }
}
