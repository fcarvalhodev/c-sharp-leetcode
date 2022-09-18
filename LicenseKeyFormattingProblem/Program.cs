using System;

namespace LicenseKeyFormattingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = LicenseKeyFormatting("2-4A0R-74K", 4);
            if (result.Equals("24A0-R74K"))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string LicenseKeyFormatting(string s, int k)
        {
            string key = string.Empty;
            char[] arr = s.ToCharArray();

            int tempCheck = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != '-')
                {
                    key = arr[i] + key;
                    tempCheck++;

                    if (tempCheck == k)
                    {
                        tempCheck = 0;
                        key = '-' + key;
                    }
                }
            }

            return key.TrimStart('-').ToUpper();
        }
    }
}
