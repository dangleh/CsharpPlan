using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StudyCsBasic.Class
{
    /*
     * The part of the program where a particular variable is accessible is termed as the Scope of that variable. 
     * A variable can be defined in a class, method, loop etc
     * 
     * So C# scope rules of variables can be divided into three categories as follows:
        Class Level Scope
        Method Level Scope
        Block Level Scope
     */

    #region Class Level Scope
    /*
     * Class Level Scope
        Declaring the variables in a class but outside any method can be directly accessed anywhere in the class.
        These variables are also termed as the fields or class members.
        Class level scoped variable can be accessed by the non-static methods of the class in which it is declared.
        Access modifier of class level variables doesn’t affect their scope within a class.
        Member variables can also be accessed outside the class by using the access modifiers.
     */
    internal class ClassLevelScope // from here class level scope starts
    {
        // this is a class level variable
        // having class level scope
        int a = 10;
        // declaring a method
        public void display()
        {
            // accessing class level variable
            Console.WriteLine(a);

        } // here method ends

    } // here class level scope ends


    #endregion


    #region Method Level Scope
    /*
     * Method Level Scope
        Variables that are declared inside a method have method level scope. These are not accessible outside the method.
        However, these variables can be accessed by the nested code blocks inside a method.
        These variables are termed as the local variables.
        There will be a compile-time error if these variables are declared twice with the same name in the same scope.
        These variables don’t exist after method’s execution is over.
     */
    internal class MethodLevelScope // from here class level scope starts
    {
        // declaring a method
        public void display()
        { // from here method level scope starts

            // this variable has
            // method level scope
            int m = 47;

            // accessing method level variable
            Console.WriteLine(m);

        } // here method level scope ends

        // declaring a method
        public void display1()

        { // from here method level scope starts

            // it will give compile time error as
            // you are trying to access the local
            // variable of method display()

            //Console.WriteLine(m);

        } // here method level scope ends

    } // here class level scope ends


    #endregion

    #region Block Level Scope
    /*
     * Block Level Scope
        These variables are generally declared inside the for, while statement etc.
        These variables are also termed as the loop variables or statements variable as they have limited their scope up to the body of the statement in which it declared.
        Generally, a loop inside a method has three level of nested code blocks(i.e. class level, method level, loop level).
        The variable which is declared outside the loop is also accessible within the nested loops. It means a class level variable will be accessible to the methods and all loops. Method level variable will be accessible to loop and method inside that method.
        A variable which is declared inside a loop body will not be visible to the outside of loop body.
     */
    internal class BlockLevelScope // from here class level scope starts
    {
        // declaring a method
        public void display()
        { // from here method level scope starts

            // this variable has
            // method level scope
            int i = 0;

            for (i = 0; i < 4; i++)
            {
                // accessing method level variable
                Console.WriteLine(i);
            }

            // here j is block level variable
            // it is only accessible inside
            // this for loop
            for (int j = 0; j < 5; j++)
            {
                // accessing block level variable
                Console.WriteLine(j);
            }

            // this will give error as block level
            // variable can't be accessed outside
            // the block

            //Console.WriteLine(j);

        } // here method level scope ends

    } // here class level scope ends


    #endregion
}
