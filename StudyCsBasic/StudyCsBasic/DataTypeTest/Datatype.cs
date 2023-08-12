using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StudyCsBasic.Datatype
{
    public class Student
    {
        public string Name { get; set; }
    }

    [TestFixture]
    internal class Datatype
    {
        #region datatype

        /*
         * All conversions from integral 
         * or floating-point numbers to Boolean values
         * convert non-zero values to true and zero values to false
         */
        [Test]
        public void ConvertToBoolean_Test()
        {
            Byte byteValue = 12;
            Assert.AreEqual(true, Convert.ToBoolean(byteValue));

            Byte byteValue2 = 0;
            Assert.AreEqual(false, Convert.ToBoolean(byteValue2));

            int intValue = -16345;
            Assert.AreEqual(true, Convert.ToBoolean(intValue));

            long longValue = 945;
            Assert.AreEqual(true, Convert.ToBoolean(longValue));

            SByte sbyteValue = -12;
            Assert.AreEqual(true, Convert.ToBoolean(sbyteValue));

            double dblValue = 0;
            Assert.AreEqual(false, Convert.ToBoolean(dblValue));

            float sngValue = .0001f;
            Assert.AreEqual(true, Convert.ToBoolean(sngValue));
        }

        /*
         * Conversions between a Boolean and the char or DateTime types are not supported,
         * so the corresponding conversion methods throw an InvalidCastException exception
         */
        [Test]
        public void InvalidConvertToBoolean_Test()
        {
            char charValue = '2';
            try
            {
                Convert.ToBoolean(charValue);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid cast from 'Char' to 'Boolean'.", e.Message);
            }
            DateTime dateValue = DateTime.Now;

            try
            {
                Convert.ToBoolean(dateValue);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid cast from 'DateTime' to 'Boolean'.", e.Message);
            }
        }

        /*
         *  The conversion methods of the Convert class convert
         *  true to 1 and false to 0
         */
        [Test]
        public void ConvertFromBoolean_Test()
        {
            bool flag = true;
            sbyte sbyteValue = 1;
            byte byteValue = 1;
            double dblValue = 1;
            Int32 int32Value = 1;
            Assert.AreEqual(byteValue, Convert.ToByte(flag));
            Assert.AreEqual(sbyteValue, Convert.ToSByte(flag));
            Assert.AreEqual(dblValue, Convert.ToDouble(flag));
            Assert.AreEqual(int32Value, Convert.ToInt32(flag));
        }


        /* 
         * The string representation of a Boolean value is defined by the case-insensitive
         * equivalents of the values of the TrueString and FalseString fields,
         * which are "True" and "False", respectively.
         * In other words, the only strings that parse successfully are 
         * "True", "False", "true", "false", or some mixed-case equivalent.
         * Tests below demonstrate some examples
         * 
         * Test input (parse value, expected parsable)
         */

        [TestCase(null, true)]
        [TestCase("", false)]
        [TestCase("True", true)]
        [TestCase("False", true)]
        [TestCase("true", true)]
        [TestCase("false", true)]
        [TestCase("    true    ", true)]
        [TestCase("TrUe", true)]
        [TestCase("fAlSe", true)]
        [TestCase("0", false)]
        [TestCase("1", false)]
        [TestCase("-1", false)]
        [TestCase("string", false)]
        public void ParseBoolean_Test(string str, bool expected)
        {
            bool parsed = false;
            try
            {
                Convert.ToBoolean(str);
                parsed = true;
                Assert.AreEqual(expected, parsed);
            }
            catch (Exception)
            {
                Assert.AreEqual(expected, parsed);
            }
        }

        /*
         Explicit Casting (manually)
         converting a larger type to a smaller size type
         double -> float -> long -> int -> char
         Note: Explicit casting rounded to the even interger.
         */
        [TestCase(9.74, 9)]
        public void ExplicitCastingDoubleToInt_Test(double input, int expected)
        {
            Assert.AreEqual(expected, (int)input);
        }

        /*
         Type Conversion
         converting a larger type to a smaller size type
         double -> float -> long -> int -> char
         Note: Type conversion rounded to the nearest interger.
         */
        [TestCase(9.74, 10)]
        public void TypeConversionDoubleToInt_Test(double input, int expected)
        {
            Assert.AreEqual(expected, Convert.ToInt32(input));
        }

        /*
         ++x (pre-increment): increment the variable, the value of the expression is the final value
         x++ (post-increment): remember the original value, then increment the variable, the value of the expression is the original value
         */
        [Test]
        public void PreIncrementAndPostIncrement_Test()
        {
            int x = 4;
            Assert.AreEqual(4, x++); //after this statement x = 5
            Assert.AreEqual(5, x);
            Assert.AreEqual(6, ++x);

            int y = 4;
            Assert.AreEqual(4, y--);//after this statement y = 3
            Assert.AreEqual(3, y);
            Assert.AreEqual(2, --y);
        }
        #endregion

        #region Data value

        /*
       The following data types are all of value type:
           bool,byte,char,decimal,double,enum,float,int,
           long,sbyte,short,struct,uint,ulong,ushort
       All the value types derive from System.ValueType,
       which in-turn, derives from System.Object.

       The system creates a separate copy of a variable 
       when pass a value-type variable from one method to another.
       If value got changed in the one method,
       it wouldn't affect the variable in another method.
        */
        [Test]
        public void PassingValueType_Test()
        {
            int i = 100;
            ChangeValue(i);
            Assert.AreEqual(100, i);
        }
        static void ChangeValue(int input)
        {
            input = 200;
        }

        /*
        Reference type data types:
            String
            Arrays (even if their elements are value types)
            Class
            Delegate

        Reference type stores the address where the value is being stored.
        In other words, a reference type contains a
        pointer to another memory location that holds the data.
         */
        [Test]
        public void PassingReferenceType_Test()
        {
            Student std = new Student();
            std.Name = "Mark";
            ChangeValue(std);
            Assert.AreNotEqual("Mark", std.Name);
        }

        static void ChangeValue(Student input)
        {
            input.Name = "Steve";
        }



        /*
         Boxing is used to store value types in the garbage-collected heap.
         Boxing is an implicit conversion of a value type to the type object 
         or to any interface type implemented by this value type.
         Boxing a value type allocates an object instance on the heap 
         and copies the value into the new object.
         
         Unboxing is an explicit conversion from the type object to a value type 
         or from an interface type to a value type that implements the interface.
         An unboxing operation consists of:
            - Checking the object instance to make sure that it is a boxed value of the given value type.
            - Copying the value from the instance into the value-type variable.
         
         When a value type is boxed, a new object must be allocated and constructed,
           therefore, boxing and unboxing are computationally expensive processes.
         */
        [Test]
        public void BoxingAndUnboxing_Test()
        {
            int i = 123;
            object obj = i; // implicit boxing

            i =321;
            Assert.AreNotEqual(i, obj);
            int j = (int)obj; // attempt to unbox
            Assert.AreEqual(123, j);
        }

        [Test]
        public void InvalidUnboxing_Test()
        {
            bool invalid = false;
            int i = 123;
            object obj = i; // implicit boxing
            try
            {
                int j = (short)obj; // attempt to unbox
            }
            catch (InvalidCastException)
            {
                invalid = true;

            }
            Assert.AreEqual(true, invalid);
        }

        #endregion


        #region String, StringBuilder

        /*
         String is a reference type, but it is immutable.
        It means once we assigned a value, it cannot be changed.
        Passing a string value to a function will create
        a new variable in the memory,and any change in the value
        in the function will not be reflected in the original value.
        */
        [Test]
        public void PassingStringReferenceType_Test()
        {
            string str = "Mark";
            ChangeValue(str);
            Assert.AreEqual("Mark", str);
        }
        static void ChangeValue(string input)
        {
            input = "Steve";
        }

        /*
        StringBuilder is mutable.
        StringBuilder performs faster than string when appending multiple string values.
        Use StringBuilder when you need to append more than three or four strings.
        */
        [Test]
        public void StringBuilderToString_Test()
        {
            StringBuilder sb = new StringBuilder("Hello World");
            Assert.AreEqual("Hello World", sb.ToString());

        }
        [Test]
        public void StringBuilderAppend_Test()
        {
            StringBuilder sb = new StringBuilder("Hello World");
            sb.Append("C#");
            Assert.AreEqual("Hello WorldC#", sb.ToString());

        }
        [Test]
        public void StringBuilderAppendLine_Test()
        {
            string expectedStr = "HelloC# world ";
            expectedStr =  expectedStr.Replace(" ", System.Environment.NewLine);
            StringBuilder sb = new StringBuilder("Hello");
            sb.AppendLine("C#");
            sb.AppendLine("world");
            Assert.AreEqual(expectedStr, sb.ToString());

        }

        [Test]
        public void StringBuilderAppendFormat_Test()
        {
            string expectedStr = "Hello world 2022";
            
            StringBuilder sb = new StringBuilder("Hello world");
            sb.AppendFormat("{0}", " 2022");
            Assert.AreEqual(expectedStr, sb.ToString());

        }


        [Test]
        public void StringBuilderInsert_Test()
        {
            string expectedStr = "Hello world 2022";

            StringBuilder sb = new StringBuilder("Hello world");
            sb.Insert(11, " 2022"); // Could trigger ArgumentOutOfRangeException when index given is out of range.
            Assert.AreEqual(expectedStr, sb.ToString());

        }

        [Test]
        public void StringBuilderRemove_Test()
        {
            string expectedStr = "Hello";

            StringBuilder sb = new StringBuilder("Hello world");
            sb.Remove(5, 6); // Could trigger ArgumentOutOfRangeException when index given is out of range.
            Assert.AreEqual(expectedStr, sb.ToString());

        }
        [Test]
        public void StringBuilderReplace_Test()
        {
            string expectedStr = "Hello there";

            StringBuilder sb = new StringBuilder("Hello world");
            sb.Replace("world", "there");
            Assert.AreEqual(expectedStr, sb.ToString());

        }

        #endregion
    }
}
