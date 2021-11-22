using System;
using System.Collections;
using System.Collections.Generic;

namespace LoggerRateLimiterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Logger logger = new Logger();
            logger.ShouldPrintMessage(1, "foo1");
            logger.ShouldPrintMessage(2, "foo2");
            logger.ShouldPrintMessage(3, "foo3");
            logger.ShouldPrintMessage(3, "foo3");
            Console.ReadKey();
        }
    }

    public class Logger
    {
        Dictionary<string, int> msgDict;

        public Logger()
        {
            msgDict = new Dictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (!this.msgDict.ContainsKey(message))
            {
                this.msgDict.Add(message, timestamp);
                Console.WriteLine(message + "-" + timestamp.ToString());
                return true;
            }

            int oldTimestamp = this.msgDict.GetValueOrDefault(message);
            if (timestamp - oldTimestamp >= 10)
            {
                msgDict.Remove(message);
                this.msgDict.Add(message, timestamp);
                Console.WriteLine(message +"-"+timestamp.ToString());
                return true;
            }
            else
                return false;
        }
    }

}
