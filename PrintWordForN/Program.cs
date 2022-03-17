using System;

namespace PrintWordForN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(input);
            string[] stringValues = input.Split(' ');
            int n = int.Parse(stringValues[0]);
            string w = stringValues[1];
            for (var x = 0; x < n; x++)
                Console.WriteLine(w);
        }
    }
}
