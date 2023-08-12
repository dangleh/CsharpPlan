using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyCsBasic.Class
{
    [TestFixture]
    internal class Static
    {

        [Test]
        public void CatStaticCount_Test() 
        {
            Cat cat1 = new Cat();
            Cat cat2 = new Cat();
            Assert.AreEqual(2, Cat.Count);
        }

        [Test]
        public void TotalIntStatic_Test()
        {
            /*
             * Static method is used globaly, call direcly though class name without init object
             * Useful when create utility methods for reuse and reduce memory consumption.
             */
            Assert.AreEqual(3, Util.TotalInt(1,2));
        }
        [Test]
        public void StaticClass_Test()
        {
            Assert.AreEqual(20, Color.Green);
            Assert.AreEqual(200, Color.Blue);
            Assert.AreEqual(10, Color.Red);
        }
    }

    public class Cat
    {
        public int Weight { get; set; }
        public int Hight { get; set; }
        /*
         * Static field is used by all the instances of class
         * Init once time when application is load into memory and release when app is close
         */
        public static int Count = 0;
        public Cat()
        {
            Weight = 20;
            Hight = 100;
            Count++;
        }
      
    }

   
    class Util
    {
        public static int TotalInt(int a, int b)
        {
            return a + b;
        }
    }

    /*
     * Static class can only contain static members (static prop, static method)
     * Cannot create instance of static class
     * 
     */
    public static class Color
    {
        //CS0708: Cannot declare instance members in a static class 
        //public int Red { get; set; }
        public static int Red;
        public static int Green;
        public static int Blue;

        //CS0132: static constructor must be parameterless
        /*static Color (int red)
        {

        }*/
        static Color ()
        {
            Red = 10;
            Green = 20;
            Blue = 200;
        }
    }
}
