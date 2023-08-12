using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace StudyCsBasic.Method
{
    [TestFixture]
    internal class Lambda
    {
        [Test]
        public void ExpressionLambda_Test()
        {
            //Expression lambda
            //(input parameter) => expression
            //Lambda converted to delegate Func
            Func<int, int> square = x => x*x;
            Assert.AreEqual(25, square(5));

            //Statement lambda
            //(input parameter) => { sequence of statements }
            //Lambda converted to delegate Func
            Func<int, bool> IsEvent = x => {
                if (x%2 == 0)
                    return true;
                return false;
            };
            Assert.AreEqual(true, IsEvent(6));
        }

        [Test]
        public void StatementLambda_Test()
        {
            //Expression lambda
            //(input parameter) => expression
            //Lambda converted to delegate Func
            Func<int, int> square = x => x*x;
            Assert.AreEqual(25, square(5));

            //Statement lambda
            //(input parameter) => { sequence of statements }
            //Lambda converted to delegate Func
            Func<int, bool> IsEvent = x => {
                if (x%2 == 0)
                    return true;
                return false;
            };
            Assert.AreEqual(true, IsEvent(6));
        }


    }
}
