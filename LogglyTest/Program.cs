using System;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator(Watch = true)]

namespace LogglyTest
{
    public class Program
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main(string[] args)
        {
            var thread1 = new Thread(() => LogDebug(10000));
            var thread2 = new Thread(() => LogError(10000));

            thread1.Start();
            thread2.Start();

            Console.ReadKey();
        }

        private static void LogDebug(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                Console.WriteLine("DEBUG: " + i);
                Log.Debug("DEBUG: " + i);
                Thread.Sleep(10);
            }
        }

        private static void LogError(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                Console.WriteLine("ERROR: " + i);
                Log.Error("ERROR: " + i);
                Thread.Sleep(10);
            }
        }
    }
}
