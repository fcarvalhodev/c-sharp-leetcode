using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GenericListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Double> numbers = new List<double>();
            do
            {
                Console.WriteLine("Enter the number: ");
                string numberString = Console.ReadLine();
                if (!double.TryParse(numberString, NumberStyles.Float, new NumberFormatInfo(), out double number))
                {
                    break;
                }
                numbers.Add(number);
                Console.WriteLine($"The average value: {numbers.Average()}");
            } while (true);
        }

        
    }
}
