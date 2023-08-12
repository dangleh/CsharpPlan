using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCsBasic._12.Stream
{
    [TestFixture]
    internal class Stream
    {
        [Test]
        public void ReadFileStream_Test()
        {
            string filepath = "data.txt";
            string output = string.Empty;
            int SIZEBUFFER = 256;
            using (var stream = new FileStream(path: filepath, mode: FileMode.Open, access: FileAccess.ReadWrite, share: FileShare.Read))
            {
                Encoding encoding = Encoding.UTF8;
                byte[] buffer = new byte[SIZEBUFFER];
                bool endread = false;
                do
                {
                    int numberRead = stream.Read(buffer, 0, SIZEBUFFER);// return number of bytes write to buffer
                    if (numberRead == 0) endread = true; // if file is empty or have read all the bytes, then end read
                    if (numberRead < SIZEBUFFER) // check if steam already read all the bytes from file, clear the rest array elements
                    {
                        Array.Clear(buffer, numberRead, SIZEBUFFER - numberRead);
                    }
                    output += encoding.GetString(buffer, 0, numberRead);
                } while (!endread);

            }

            Assert.AreEqual("data is here", output);
        }


        [Test]
        public void WriteFileStream_Test()
        {
            string filepath = "data2.txt";
            string s1 = "Data is here \n";
            string s2 = "The end";
            using (var stream = new FileStream(path: filepath, mode: FileMode.Create, access: FileAccess.Write, share: FileShare.None))
            {

                Encoding encoding = Encoding.UTF8;

                byte[] buffer = encoding.GetBytes(s1);
                stream.Write(buffer, 0, buffer.Length);

                buffer = encoding.GetBytes(s2);
                stream.Write(buffer, 0, buffer.Length);
            }
            byte[] output = File.ReadAllBytes(filepath);
            string outString = Encoding.UTF8.GetString(output);
            Assert.AreEqual(s1 + s2, outString);
        }


        /*
         * The MemoryStream uses to deals with data directly in memory, 
         * as the name implies and its often used to deal with bytes coming from another place,
         * e.g. a file or a network location, without locking the source.
         */
        [Test]
        public void MemoryStream_Test()
        {
            string output = String.Empty;
            byte[] fileContents = File.ReadAllBytes("data.txt");
            using (MemoryStream memoryStream = new MemoryStream(fileContents))
            {
                using (TextReader textReader = new StreamReader(memoryStream))
                {
                    string line;
                    while ((line = textReader.ReadLine()) != null)
                    {
                        output += line;
                    }
                }
            }
            Assert.AreEqual("data is here", output);
        }


        [Test]
        public void StreamWriter_Test()
        {
            string fileName = "data3.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write("Necrons dynasty");
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            byte[] output = File.ReadAllBytes(fileName);
            string outString = Encoding.UTF8.GetString(output);
            Assert.AreEqual("Necrons dynasty", outString);
        }

    }
}
