using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudyCsBasic.Class
{

    public class Animal
    {
        /*
         * Modifier	        Description
            public	        The code is accessible for all classes
            private	        The code is only accessible within the same class
            protected	    The code is accessible within the same class, or in a class that is inherited from that class.
            internal	    The code is only accessible within its own assembly, but not from another assembly.  
        */


        //When a variable is declared directly in a class, it is often referred to as a field (or attribute).
        //private will be default modifier when not declare
        //private string color = "red";
        string color = "red"; //field

        private int age;

        public string Color   // property
        {
            get { return color; }   // get method
            set { color = value; }  // set method
        }

        //Automatic Properties(Short Hand)
        public string Name { get; set; } = String.Empty;
        protected string Gender { get; set; }

        //A constructor is a special method that is used to initialize objects.
        //The advantage of a constructor, is that it is called when an object of a class is created.
        //It can be used to set initial values for fields

        //Constructor name must match the class name, and it cannot have a return type
        //Constructor is called when the object is created
        //All classes have constructors by default: if you do not create a class constructor yourself,
        //C# creates one for you. However, then you are not able to set initial values for fields

        //Empty constructor
        public Animal()
        {

        }
        //Constructor with params
        public Animal(string color)
        {
            this.Color = color;
        }


        /*
         * Destructors in C# are methods inside the class used to destroy instances of that class when they are no longer needed.
         * The Destructor is called implicitly by the Garbage collector and therefore programmer has no control as 
         * when to invoke the destructor
         * 
         *  - Destructor is unique to its class i.e. there cannot be more than one destructor in a class
            - A Destructor is unique to its class i.e. there cannot be more than one destructor in a class.
            - A Destructor has no return type and has exactly the same name as the class name (Including the same case).
            - It is distinguished apart from a constructor because of the Tilde symbol (~) prefixed to its name.
            - A Destructor does not accept any parameters and modifiers.
            - It cannot be defined in Structures. It is only used with classes.
            - It cannot be overloaded or inherited.
            - It is called when the program exits.
            - Internally, Destructor called the Finalize method on the base class of object.
         */
        //Destructor
        ~Animal()
        {
            Console.WriteLine("Destructor was called");
        }

        //Method
        public string GetColor()
        {
            return color;
        }
    }

    public class Dog : Animal 
    {
       public string GetAge()
        {
            //CS0122 Inacessable due to protection level
            // age is private property
            //return this.age;
            return "";
        }
        public string GetGender()
        {
            //Gender property is acessable because it is protected 
            return this.Gender;
        }
    }


    [TestFixture]
    internal class ClassTest
    {
        [Test]
        public void DefaultConstructor_Test()
        {
            Animal animal = new Animal();

            //As field color is associated with property Color
            Assert.AreEqual("red", animal.Color);
            //CS0122 Inacessable due to protection level
            // age is private property
            //animal.age;


        }
        [Test]
        public void ConstructorWithParams_Test()
        {
            Animal animal = new Animal(); // Color is red
            Animal animalP = new Animal("Blue"); // Color is blue


            Assert.AreEqual("Blue", animalP.Color);
            Assert.AreNotEqual(animal.Color, animalP.Color);

            //CS0122 Inacessable due to protection level
            // age is private property
            //animal.age;

        }
        [Test]
        public void Method_Test()
        {
            Animal animal = new Animal(); // Color is red
            Animal animalP = new Animal("Blue"); // Color is blue

            Assert.AreEqual("Blue", animalP.GetColor());
            Assert.AreNotEqual(animal.GetColor(), animalP.GetColor());
        }
    }
}
