using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCsBasic.OOP
{

    public interface IVehicle
    {
        string Hook();
        string Fuel();

    }

    public class Car : IVehicle
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string FuelType { get; set; }
        public Car()
        {
            Type = "Sedan";
            Name = "Civic";
            FuelType = "Gasoline";
        }
        public string Hook()
        {
            return "Tit Tit";
        }

        public string Fuel()
        {
            return FuelType;
        }
    }
    public class Bike : IVehicle
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string FuelType { get; set; }

        public Bike()
        {
            Type = "Naked bike";
            Name = "H2R";
            FuelType = "Diesel";
        }
        public string Hook()
        {
            return "Bin Bin";
        }

        public string Fuel()
        {
            return FuelType;
        }
    }


    abstract class Animal
    {
        public abstract string AnimalSound();

    }

    class Pig : Animal
    {
        //The override modifier is required to extend or modify the abstract
        //or virtual implementation of an inherited method, property, indexer, or event.
        public override string AnimalSound()
        {
            return "wee wee";
        }
    }
    class Cat : Animal
    {
        public override string AnimalSound()
        {
            return "moew moew";
        }
    }


    [TestFixture]
    internal class OOP
    {
        static string ShowFuel(IVehicle vc)
        {
            return vc.Fuel();
        }

        [Test]
        public void InterfaceImplementation_Test()
        {
            //Bike and Car both implement interface IVehicle which have method Hook()
            Bike bike = new Bike();
            Car car = new Car();

            //ShowFuel() method except IVehicle as param
            //Because Bike and Car implement IVehicle inteface, both will be excepted as pramameter
            ShowFuel(bike);
            ShowFuel(car);


        }
        [Test]
        public void AbstractClassOverriding_Test()
        {
            //Pig and Cat both inherit Animal class
            Pig pig = new Pig();
            Cat cat = new Cat();
            //Pig and Cat override abstract method AnimalSound() with it own implementation
            Assert.AreNotEqual(pig.AnimalSound(), cat.AnimalSound());

            Assert.AreNotEqual(pig.GetType(), cat.GetType());

        }

        #region Overload

        /*
         * Method Overloading is the common way of implementing polymorphism. 
         * It is the ability to redefine a function in more than one form.
         * A user can implement function overloading by defining two or more functions in a class sharing the same name.
         * C# can distinguish the methods with different method signatures
         * 
         * - Overloaded methods are differentiated based on the number and type of the parameters passed as arguments to the methods.
         * - You can not define more than one method with the same name, Order and the type of the arguments. It would be compiler error.
         * - The compiler does not consider the return type while differentiating the overloaded method.
         *      But you cannot declare two methods with the same signature and different return type.
         *      It will throw a compile-time error. If both methods have the same parameter types, but different return type, then it is not possible.
         * 
         */
        static string ConCat(string first, string second)
        {
            return first + " " + second;
        }
        static string ConCat(string[] list)
        {
            return String.Join(" ", list);
        }

        [Test]
        public void MethodOverloading_Test()
        {
            string out1 = ConCat("Mark", "Billy");
            string out2 = ConCat(new string[] { "Mark", "Billy" });

            Assert.AreEqual(out1, out2);
        }

        #endregion
    }
}
