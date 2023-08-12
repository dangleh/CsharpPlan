using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyCsBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            Console.ReadKey();
        }


        private static void ThreadOne()
        {
            Thread.Sleep(5000);
            Console.WriteLine("ThreadOne done");
        }
        private static void ThreadTwo()
        {
            Thread.Sleep(5000);
            Console.WriteLine("ThreadTwo done");
        }
    }
}
