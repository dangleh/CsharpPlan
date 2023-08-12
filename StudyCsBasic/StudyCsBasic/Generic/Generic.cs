using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCsBasic.Generic
{
    [TestFixture]
    internal class Generic
    {
        /*
         * IList interface inherits IEnumerable and ICollection,
         * the same function as adding and removing items,
         * but it is different in that it needs to manipulate the items with known positions in the list through the index.
         * 
         */
        static void Show(IList<string> list)
        {
            // Iterate through list
            foreach (string str in list)
            {
                Console.WriteLine("\t" + str);
            }
        }

        [Test]
        public void IList_Test()
        {
            
            string[] subjects = { "OS", "CN", "PHP", "C/CPP",
                          "Java/Jsp", "Python/R" };

            List<string> data = new List<string>();
            data.Add("sai");
            data.Add("sravan");
            data.Add("jyothika");

            Show(data);
            Show(subjects);
        }
    }
}
