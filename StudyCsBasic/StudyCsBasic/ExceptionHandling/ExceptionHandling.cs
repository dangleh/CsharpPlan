using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudyCsBasic.ExceptionHandling
{
    [TestFixture]
    internal class ExceptionHandling
    {
        /*
         * An exception is any error condition or unexpected behavior that is encountered by an executing program.
         * Exceptions can be thrown because of a fault in your code or in code that you call (such as a shared library),
         * unavailable operating system resources, unexpected conditions that the runtime encounters 
         * 
         */

        /*
         * A common usage of catch and finally together is to obtain and use resources in a try block,
         * deal with exceptional circumstances in a catch block, and release the resources in the finally block.
         */
        [Test]
        public void ExceptionHandlingWithTryCatchFinally_Test()

        {
            string path = "data.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            char[] buffer = new char[10];
            try
            {
                file.ReadBlock(buffer,0, buffer.Length);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Error reading from {0}. Message = {1}", path, e.Message); 
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                    file = null;
                }
            }

            Assert.AreEqual(null, file);
          
        }

        [Test]
        public void ExceptionHandlingWithTryCatch_Test()
        {
            bool fileNotFound =  false;
            try
            {
                using (StreamReader sr = File.OpenText("datas.txt"))
                {
                    Console.WriteLine($"The first line of this file is {sr.ReadLine()}");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
                fileNotFound = true;
            }
            Assert.AreEqual(true, fileNotFound);
        }

        [Test]
        public void ExceptionHandlingWithTryAndMultipleCatch_Test()
        {
            int catchException = 0;
            try
            {
                string s = null;
                ProcessString(s);
            }
            // Most specific:
            catch (ArgumentNullException e)
            {
                Console.WriteLine("{0} First exception caught.", e); 
                catchException = 1;
            }
            // Least specific:
            catch (Exception e)
            {
                Console.WriteLine("{0} Second exception caught.", e);
                catchException = 2;
            }
            Assert.AreEqual(1, catchException);


            try
            {
                string s = String.Empty;
                ProcessString(s);
            }
            // Most specific:
            catch (ArgumentNullException e)
            {
                Console.WriteLine("{0} First exception caught.", e);
                catchException = 1;
            }
            // Least specific:
            catch (Exception e)
            {
                Console.WriteLine("{0} Second exception caught.", e);
                catchException = 2;
            }
            Assert.AreEqual(2, catchException);
        }

        static void ProcessString(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(paramName: nameof(s), message: "Parameter can't be null");
            }
            if (s.Length == 0)
            {
                throw new Exception( message: "Parameter can't be empty");
            }
        }


    }
}
