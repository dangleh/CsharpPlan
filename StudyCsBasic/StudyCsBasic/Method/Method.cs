using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StudyCsBasic.Method
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
        public int AddAge(int num)
        {
            Age += num;
            return Age;
        }
        public int AddRangeAge(params int[] list)
        {
            foreach (int i in list)
            {
                Age += i;
            }
            return Age;
        }
    }
    [TestFixture]
    internal class Method
    {
        [Test]
        public void MethodWithArgument_Test()
        {
            Person person = new Person(1, "Mark");
            //Method 
            person.AddAge(1);

            Assert.AreEqual(2, person.Age);
        }
        [Test]
        public void MethodWithParamsArgument_Test()
        {
            Person person = new Person(1, "Mark");
            //Param method 
            person.AddRangeAge(1, 2, 2);

            Assert.AreEqual(6, person.Age);

            Person person2 = new Person(1, "John");
            //Pass array 
            int[] list = { 1, 2, 5 };
            person2.AddRangeAge(list);

            Assert.AreEqual(9, person2.Age);
        }
        /*
         * In modifer stop you from modify the value of parameter
         * When using with reference type, it only prevent you from assigning new reference
         */

        static void ModifyPerson(in Person person)
        {
            //CS8331 can not assign to variable "in person" because it is a readonly variable
            //person = new Person(1, "Mark");

            person.Name = "Lucas";
        }

        [Test]
        public void InModifier_Test()
        {
            Person person = new Person(1, "Mark");
            ModifyPerson(person);
            Assert.AreEqual("Lucas", person.Name);
        }
        static void IncreaseValue(ref int value)
        {
            value++;
        }

        /*
         * Ref modifier allows you to have option to assign new reference type and have it refected outside the method
         * Note the parmeter cannot be a constant
         * Parameter must be init before passing to the method
         */
        [Test]
        public void RefMofier_Test()
        {
            int value = 5;
            IncreaseValue(ref value);
            Assert.AreEqual(6, value);
        }
        /*
       * Out modifier works like Ref, but parameter no need be init before passing to the method
       * parameter will work as a value holder when method return result.
       * Parameter need to init inside that method.
       */
        static void DecreaseValue(out int value)
        {
            value = 0;
            value--;
        }
        [Test]
        public void OutMofier_Test()
        {
            int value = 5;
            DecreaseValue(out value);
            Assert.AreEqual(-1, value);
        }

    }
}
