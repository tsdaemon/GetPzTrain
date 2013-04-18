using GetPzTrainLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetPzTrainConsole
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        static void Main(string[] args)
        {
            Params p = new Params()
            {
                Date = DateTime.Parse(args[0]),
                From = int.Parse(args[1]),
                To = int.Parse(args[2]),
                MinTicketsCount = int.Parse(args[3]),
                MaxArriveTime = int.Parse(args[4])
            };
            Console.WriteLine("Start to search...");

            IEnumerable<JToken> trains;
            do
            {
                Console.WriteLine("Sending request...");
                var j = PZKnocker.SendRequest(PZKnocker.Address, p);
                Console.WriteLine("We got it! Searching...");
                trains = j.HaveTrains(p);
                if (trains != null && trains.Count() > 0) break;
                Console.WriteLine("Nothing...");
                Thread.Sleep(600000);
            } while (true);

            Console.WriteLine("We have found it!");
            foreach (var j in trains)
            {
                Console.WriteLine("Train {0}, finish at {1}, tickets: {2}", j["train"]["0"], j["prib"], j["p"]);
            }

            ToFront();

            Console.ReadLine();
        }

        public static void ToFront()
        {
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            SetForegroundWindow(handle);
        }
    }
}
