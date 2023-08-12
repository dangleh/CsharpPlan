using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StudyCsBasic.DataTypeTest
{
    [TestFixture]
    internal class Collection
    {
        #region Array
        [Test]
        public void AccessArrayElement_Test()
        {
            /*
            CS0029: Cannot implicitly convert type 'int' to 'string'
                string[] cars = { "Volvo",1}
            replace 1 with string like "1"
            */
            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };

            Assert.AreEqual("BMW", cars[1]); // Could trigger ArgumentOutOfRangeException when index given is out of range.
        }

        [Test]
        public void ChangeArrayElement_Test()
        {
            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
            cars[0] = "Toyota";
            Assert.AreEqual("Toyota", cars[0]);

        }
        [Test]
        public void Access2DArrayElement_Test()
        {
            int[,] numbers = { { 1, 2, 3 }, { 4, 5, 6 } };

            Assert.AreEqual(1, numbers[0, 0]);
            Assert.AreEqual(4, numbers[1, 0]);
            Assert.AreEqual(3, numbers[0, 2]);
            Assert.AreEqual(5, numbers[1, 1]);
        }

        #endregion

        #region List

        [Test]
        public void AccessListElement_Test()
        {
            //Empty list 
            List<int> listInt = new List<int>();
            //List with capacity
            List<int> listInt5 = new List<int>(5);
            //List with elements
            List<int> listIntE = new List<int>() { 1, 2, 2, 3, 3, 4 };

            //Add element 
            listInt.Add(1);
            listInt.Add(2);
            Assert.AreEqual(1, listInt[0]);
            Assert.AreEqual(2, listInt[1]);

            listInt5.Add(1);
            listInt5.Add(2);
            listInt5.Add(3);
            listInt5.Add(4);
            listInt5.Add(5);
            listInt5.Add(6); // Cap will auto increase double
            Assert.AreEqual(10, listInt5.Capacity);

        }
        [Test]
        public void ListExtendMethod_Test()
        {
            List<int> listInt = new List<int>() { 1, 4, 6, 5, 2, 3, 4 };

            //Contains check is Value exist in the list
            Assert.AreEqual(true, listInt.Contains(5));
            Assert.AreEqual(false, listInt.Contains(8));
            // IndexOf return index of first match Value
            Assert.AreEqual(1, listInt.IndexOf(4));

            //LastIndexOf return index of last match Value
            Assert.AreEqual(6, listInt.LastIndexOf(4));

            // Remove() remove first elment match the Value
            Assert.AreEqual(true, listInt.Remove(4));

            //Reverse() reverse position of elements
            Assert.AreEqual(1, listInt[0]);
            listInt.Reverse();
            Assert.AreEqual(4, listInt[0]);

            //Sort() sort list with ascending order
            listInt.Sort();
            Assert.AreEqual(1, listInt[0]);
            Assert.AreEqual(2, listInt[1]);

            //Clear() remove all element
            listInt.Clear();
            Assert.AreEqual(0, listInt.Count);
        }

        #endregion

        #region ArrayList

        /*
         ArrayList hold objects  
         */
        [Test]
        public void AccessArrayList_Test()
        {
            //Empty array list 
            ArrayList arrList = new ArrayList();
            //Empty array list with cap
            ArrayList arrList5 = new ArrayList(5);
            //Array list with element
            ArrayList arrListE = new ArrayList() { 1, "Abc", 3, 4.323, "cool" };

            //Add element 
            arrList.Add(11);
            arrList.Add("cool");
            Assert.AreEqual(11, arrList[0]);
            Assert.AreEqual("cool", arrList[1]);

            arrList5.AddRange(arrListE);
            arrList5.Add(6); // Cap will auto increase double
            Assert.AreEqual(10, arrList5.Capacity);

        }
        public void ArrayListExtendMethod_Test()
        {
            ArrayList listInt = new ArrayList() { 1, "A", 4, "C", 2, 3, "A" };

            //Contains check is Value exist in the list
            Assert.AreEqual(true, listInt.Contains(5));
            Assert.AreEqual(false, listInt.Contains(8));
            // IndexOf return index of first match Value
            Assert.AreEqual(1, listInt.IndexOf("A"));

            //LastIndexOf return index of last match Value
            Assert.AreEqual(6, listInt.LastIndexOf("A"));

            //Reverse() reverse position of elements
            Assert.AreEqual(1, listInt[0]);
            listInt.Reverse();
            Assert.AreEqual("A", listInt[0]);

            //Sort() sort list with ascending order
            listInt.Sort();
            Assert.AreEqual(1, listInt[0]);
            Assert.AreEqual(2, listInt[1]);

            //Clear() remove all element
            listInt.Clear();
            Assert.AreEqual(0, listInt.Count);
        }


        #endregion

        #region SortedList

        /*
         * SortedList is a hashtable but value is sorted by key, this sort operation is manage automaticly when ever new element is added.
         * 
         */
        [Test]
        public void SortedList_Test()
        {
            SortedList sortedList = new SortedList();
            sortedList.Add(1, "A");
            sortedList.Add(3, "C");
            sortedList.Add(2, "B");
            sortedList.Add(4, "D");

            IList keys = sortedList.GetKeyList();

            Assert.AreEqual(1, keys[0]);
            Assert.AreEqual(2, keys[1]);
            Assert.AreEqual(3, keys[2]);
            Assert.AreEqual(4, keys[3]);
        }

        #endregion

        #region Dictionary


        /*
         * Dictionary is a replacement for Hashtable 
         * Store value as Key-Value pair
         
         */
        [Test]
        public void Dictionary_Test()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("Apple", "Iphone");
            dict.Add("Samsung", "Samsung Galaxy");
            dict.Add("Nokia", "Lumia");


            Assert.AreEqual(true, dict.ContainsKey("Apple"));
            Assert.AreEqual("Iphone", dict["Apple"]);
            Assert.AreEqual("Samsung Galaxy", dict["Samsung"]);

        }

        #endregion

        #region Stack

        /*
         * Stack is a special type of collection that stores elements in LIFO style (Last In First Out)
         * Stack is usefull to store teporary data in LIFO stype

         */
        [Test]
        public void Stack_Test()
        {
            List<string> expectedOrder = new List<string>() { "E", "D", "C", "B", "A" };
            Stack<string> stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Push("D");
            stack.Push("E");

            for (int i = 0; i < stack.Count; i++)
            {
                Assert.AreEqual(expectedOrder[i], stack.Pop());
            }
        }



        #endregion

        #region Queue
        /*
         * Queue is a special type of collection that stores elements in FIFO style (First In First Out)
         * 
         */
        [Test]
        public void Queue_Test()
        {
            List<string> expectedOrder = new List<string>() { "A", "B", "C", "D", "E" };
            Queue<string> stack = new Queue<string>();
            stack.Enqueue("A");
            stack.Enqueue("B");
            stack.Enqueue("C");
            stack.Enqueue("D");
            stack.Enqueue("E");

            for (int i = 0; i < stack.Count; i++)
            {
                Assert.AreEqual(expectedOrder[i], stack.Dequeue());
            }
        }
        #endregion


        #region IEnumerable
        /*
         * IEnumerable is  pre-define interface in System.Colections namespace
         * IEnumerable supports simple iteration over a non-generic collection
         * 
         * 
         */

        public class Person
        {
            public string firstName;
            public string lastName;

            public Person(string firstName, string lastName)
            {
                this.firstName=firstName;
                this.lastName=lastName;
            }
        }
        /*
         * Collection of Person objects. This class implements IEnumerable so that it can be used with ForEach syntax
         */
        public class People : IEnumerable
        {
            private Person[] _people;
            public People(Person[] pArr)
            {
                _people = new Person[pArr.Length];
                for (int i = 0; i < pArr.Length; i++)
                {
                    _people[i] = pArr[i];
                }
            }
            //Implementation for the GetEnumerator method
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }
            public PeopleEnum GetEnumerator()
            {
                return new PeopleEnum(_people);
            }
        }
        //When implement IEnumerable, you must also implement IEnumerator
        public class PeopleEnum : IEnumerator
        {
            public Person[] _people;

            //Enumerators are positioned befor the first element
            //until the first MoveNext() call
            int position = -1;
            public PeopleEnum(Person[] list)
            {
                _people = list;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public Person Current
            {
                get
                {
                    try
                    {
                        return _people[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public bool MoveNext()
            {
                position++;
                return position < _people.Length;
            }
            public void Reset()
            {
                position = -1;
            }
        }
        [Test]
        public void IEnumerableImplimentation_Test()
        {
            Person[] peopleArray = new Person[3]
            {
                new Person("Join","Smith"),
                new Person("Alan","Wallker"),
                new Person("Alice","Rose"),
            };
            People peopleList = new People(peopleArray);
            int i = 0;
            foreach (Person p in peopleList)
            {

                Assert.AreSame(peopleArray[i].firstName, p.firstName);
                i++;
            }
        }
        #endregion

        #region yield

        /*
         * yeild return: provide the next value in iteration.
         */
        IEnumerable<int> ProduceEvenNumber(int upto)
        {
            for (int i = 0; i<= upto; i +=2)
            {
                yield return i;
            }
        }
        [Test]
        public void YieldReturn_Test()
        {
            var numbers = ProduceEvenNumber(5);
            foreach (int i in numbers)
            {
                Assert.AreEqual(true, i % 2==0);
            }
        }


        /*
         * yeild break: exolicitly singal the end of iteration.
         */
        IEnumerable<int> TakenWhilePositive(IEnumerable<int> numbers)
        {
            foreach (int i in numbers)
            {
                if (i >0)
                {
                    yield return i;
                }
                else
                {
                    yield break;
                }

            }
        }
        [Test]
        public void YieldBreak_Test()
        {
            var numbers = TakenWhilePositive(new[] { 3, 4, 5, -1, -3, 4 });

            Assert.AreEqual(3, numbers.ToList().Count);

            foreach (int i in numbers)
            {
                Assert.AreEqual(true, i >0);
            }
        }
        #endregion


        #region IComparable 
        /*
         * Defines a deneralized type-specific comparison method that a value type or class implements to order or sort its instances
         */

        public class Weight : IComparable
        {
            protected double weigtPound;
            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                Weight otherWeight = obj as Weight;
                if (otherWeight != null)
                    return this.weigtPound.CompareTo(otherWeight.weigtPound);
                else
                    throw new ArgumentException("Object is not a Weight");
            }
            public double Pound
            {
                get
                {
                    return this.weigtPound;
                }
                set
                {
                    this.weigtPound = value;
                }
            }
            public double Kilogram
            {
                get
                {
                    return this.weigtPound / 2.2;
                }
                set
                {
                    this.weigtPound = value *2.2;
                }
            }
        }

        [Test]
        public void IComparableSortByWeight_Test()
        {
            ArrayList weights = new ArrayList();
            Random random = new Random();
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int w = random.Next(0, 100);
                Weight weight = new Weight();
                weight.Kilogram = w;
                weights.Add(weight);

            }
            weights.Sort();

            double previousWeight = 0;
            foreach (Weight weight in weights)
            {
                Assert.LessOrEqual(previousWeight, weight.Pound);
                previousWeight = weight.Pound;
            }
        }

        #endregion
        /*
         * Create custom comparer for object 
         */
        #region IComparer
        class Student
        {
            public int No { get; set; }
            public string ClassName { get; set; }

        }
        class NoComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.No.CompareTo(y.No);
            }
        }
        class ClassNameComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.ClassName.CompareTo(y.ClassName);
            }
        }

        [Test]
        public void IComparerSortByNo_Test()
        {
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            student1.No = 1;
            student2.No = 2;
            student3.No = 3;

            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student3);
            students.Add(student2);

            students.Sort(new NoComparer());

            int previouNo = 0;
            foreach (Student student in students)
            {
                Assert.LessOrEqual(previouNo, student.No);
                previouNo = student.No;
            }
        }
        [Test]
        public void IComparerSortByClassName_Test()
        {
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            student1.ClassName = "12A1";
            student2.ClassName = "12A2";
            student3.ClassName = "12A3";

            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student3);
            students.Add(student2);

            students.Sort(new ClassNameComparer());

            string previousClassName = "";
            foreach (Student student in students)
            {
                Assert.AreEqual(true, previousClassName.CompareTo(student.ClassName) <0);
                previousClassName = student.ClassName;
            }
        }
        #endregion
    }
}
