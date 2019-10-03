using System;
using System.Collections.Generic;

namespace lab_36_refrence_value_types
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             PRIMITIVE TYPES: int, bool, char, struct
             STored in fast stack memory
             values stored with declaration in live, fast code
             destroyed immediatley as well
             ==VALUE TYPES as VALUE stored in STACK MEMORY with declaration
             var x=10;  and 10 stored on stack
             copy of a value type is independant 
             */

            decimal x = 10;
            decimal y = x;

            x = 1000;
            y = 3333;

            Console.WriteLine($"global var x = {x} and var y = {y}");

            //pass x and y into a method
            DoThis(x, y);

            Console.WriteLine($"global var x = {x} and var y = {y}");

            //pass x and y  by reference into DoThisPermenantly()
            DoThisPermenantly(ref x, ref y);

            Console.WriteLine($"reference global var x = {x} and var y = {y}");

            //Reference types
            //Value types are primitives eg int, held on fast stack
            //reference types are LARGE OBJECTS
            //Shortcut held on fast stack
            //actual object held on slower heap (large memory)
            //stack                         heap
            //int x = 10
            //list<string> mylist >>>>>>>>>>{"one","two"}

            //when you copy a reference tyoe then by default you only copy the pointer

            int[] myArray = { 100, 200, 300 };

            var myArray2 = myArray;

            Console.WriteLine(string.Join(", ", myArray));
            Console.WriteLine(string.Join(", ", myArray2));

            myArray[2] = 400;

            Console.WriteLine(string.Join(", ", myArray));
            Console.WriteLine(string.Join(", ", myArray2));

            //REFERENCE TYPES are naturally treated as global when passed into a method

            var myList = new List<string>() { "first", "second" };

            Console.WriteLine(string.Join(", ", myList));

            DoThisToMyList(myList);

            Console.WriteLine(string.Join(", ", myList));
        }

        static void DoThisToMyList(List<string> list)
        {
            list.Add("third");
            list.Add("fourth");
            list.Add("fifth");
        }

        //method to change x to x^2 and y^3
        static void DoThis(decimal x, decimal y)
        {
            x = x * x;
            y = y*y*y;
            Console.WriteLine($"local var x = {x} and var y = {y}");
        }

        static void DoThisPermenantly(ref decimal x, ref decimal y)
        {
            x = x * x;
            y = y * y * y;
            Console.WriteLine($"reference local var x = {x} and var y = {y}");
        }
    }
}
