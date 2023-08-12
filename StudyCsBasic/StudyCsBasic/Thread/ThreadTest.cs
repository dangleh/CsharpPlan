using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using StudyCsBasic.Method;

namespace StudyCsBasic.ThreadTest
{
    [TestFixture]
    internal class ThreadTest
    {
        [Test]
        public void Thread_Test()
        {
            var watch = new Stopwatch();
            watch.Start();
            Thread thOne = new Thread(ThreadOne);
            Thread thTwo = new Thread(ThreadTwo);


            thOne.Start();
            thTwo.Start();

            //Stop main thread until thOne and thTwo done 
            thOne.Join();
            thTwo.Join();

            watch.Stop();
            Assert.IsTrue(watch.ElapsedMilliseconds < 6000);
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



        /*
            await can only be used in async method         
         */
        [Test]
        public static async Task Task_Test()
        {
            var watch = new Stopwatch();
            watch.Start();
            string str = "C#";
            var result = await Task.WhenAll(TaskOne(), TaskTwo(str));

            watch.Stop();
            Assert.IsTrue(watch.ElapsedMilliseconds < 6000);
            Assert.AreEqual("Hello", result[0]);
            Assert.AreEqual("World " + str, result[1]);
        }

        private static async Task<string> TaskOne()
        {
            await Task.Delay(5000);
            Console.WriteLine("TaskOne done");
            return "Hello";
        }
        private static async Task<string> TaskTwo(string str)
        {
            await Task.Delay(4000);
            Console.WriteLine("TaskOne done");
            return "World " + str;
        }


        /*
         * Threadpool reuse thread give better performance then create each thread individually
         */
        [Test]
        public void ThreadPool_Test()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod));
            }
        }

        public static void ThreadMethod(object obj)
        {
            Thread thread = Thread.CurrentThread;
            string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}";
            Console.WriteLine(message);
        }

    }

}
