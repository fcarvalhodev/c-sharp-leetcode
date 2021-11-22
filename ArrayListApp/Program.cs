using System;
using System.Collections;

namespace ArrayListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(5);
            arrayList.AddRange(new int[] { 6, -7, 8 });
            arrayList.AddRange(new object[] { "Marcin", "Marry" });
            arrayList.Insert(5, 7.8);
            foreach (var element in arrayList)
                Console.WriteLine(element);
        }
    }
}
