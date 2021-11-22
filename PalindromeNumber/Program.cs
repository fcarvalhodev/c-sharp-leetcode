using System;

namespace PalindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 121;
            string value = x.ToString();
            string reverse = "";
            for (int j = value.Length-1; j >= 0; j--)
                reverse += value[j];

            bool result = value.ToLower().Equals(reverse.ToLower());
            Console.WriteLine(result);

        }
    }
}
