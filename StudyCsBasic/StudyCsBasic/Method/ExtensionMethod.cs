using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCsBasic.Method
{

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Student(string firstName, string lastName, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }

    }
    [TestFixture]
    public static class ExtensionMethod
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
        }

        public static int Age( this Student student)
        {
            DateTime now = DateTime.Now;
            
            return now.Year - student.BirthDate.Year;
        }
        public static string FullName(this Student student)
        {
            return student.FirstName + " " + student.LastName;
        }
    }
    public class ExtensionMethodTest
    {

        [Test]
        public void WordCountExtension_Test()
        {
            string s = "Hello world";
            Assert.AreEqual(2, s.WordCount());
        }

        [Test]
        public void PersomExtensionMethod_Test()
        {
            Student student = new Student("Mark","Johanson", new DateTime(1999,3,12));
            Assert.AreEqual(23, student.Age());
            Assert.AreEqual("Mark Johanson", student.FullName());
        }
    }
}
