using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCsBasic.Method
{
    [TestFixture]
    internal class Linq
    {
        [Test]
        public void LinQQuerySyntax_Test()
        {
            int[] scores = { 1, 2, 3, 4, 5, 6 };
            IEnumerable<int> results = from score in scores where score >3 select score;
            Assert.AreEqual(3, results.Count());


        }
        [Test]
        public void LinQMethodSyntax_Test()
        {
            int[] scores = { 1, 2, 3, 4, 5, 6 };

            int result = scores.Where(num => num %2 == 0).Sum();
            Assert.AreEqual(12, result);
            //Result: 6
            IEnumerable<int> results = scores.Where(num => num %2 == 0).OrderByDescending(num => num);
            Assert.AreEqual(6, results.First());
            //Result: 0 for not found
            int result2 = scores.Where(num => num  == 7).SingleOrDefault();
            Assert.AreEqual(0, result2);
            //Result: 1
            int result3 = scores.Where(num => num  == 1).SingleOrDefault();
            Assert.AreEqual(1, result3);

            IEnumerable<int> results2 = scores.Where(num => num > 2).SkipWhile(num => num %2 != 0);
            //Result: 4, 5, 6
            Assert.AreEqual(3, results2.Count());

        }
    }
}
