using System;

namespace lab_25_data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            //integers
            byte byteMin = 0;
            byte byteMax = 255;
            //0
            byte b_Min_in_binary = 0b_00000000;
            //255
            byte b_Max_in_binary = 0b_11111111;

            //0
            byte b_Min_in_Hex = 0x_00;
            //255
            byte b_Max_in_Hex = 0x_ff;

            //byte b_Negative_is_invalid = -1;

            //letters are also stored as numbers

            char letter_01 = 'a';

            Console.WriteLine(letter_01);
            Console.WriteLine((int)letter_01);

            //be aware, a string is stored as an array of chars
            string String = "hello";
            char[] charArray = "hello".ToCharArray();

            Console.WriteLine($"Fist letter has index 0. ie. {String[0]} { charArray[0]}");


            //whole numbers
            //int
            var numberOfAnyType = 27;
            //int is 32 bits
            //but 1 bit is reserved for + or -
            //positive = 0 to max-1
            //negative = 0 to min+1
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);

            //short
            short short01 = 9999;
            //short is 16 bits

            //long
            long long01 = 64;
            //long is 64 bits

            //decimal numbers
            //float
            float f = 1.23F;
            //double
            double double01 = 1.23D;
            //decimal
            decimal decimal01 = 1.23M;

            //floats and doubles are not exact EVER because you're converting from binary to decimal

            double total = 0;
            for (int i = 0; i < 8192; i++)
            {
                total += 0.7;
            }
            Console.WriteLine(total);


            decimal total2 = 0M;
            for (int i = 0; i < 8192; i++)
            {
                total2 += 0.7M;
            }
            Console.WriteLine(total2);

            int total3 = 0;
            for (int i = 0; i < 8192; i++)
            {
                total3 += 7;
            }
            
            Console.WriteLine(total2/100);

            //positive int
            uint positiveInt = 500;
            uint MaxPositiveInt;
            Console.WriteLine(uint.MaxValue);

            //Operators
            //a + b
            //a & b are Operands
            //+ is an Operator
            //Urany
            //Increment
            //x++       OR      ++x
            int x = 0;
            x++;
            ++x;
            //both add 1
            //generally use x++ and if possible use on seperate line
            int y1 = 1000;
            int y2 = 1000;
            int z1 = y1++;          //z1 = 1000     THEN    incremented
            int z2 = ++y2;          //incremented   THEN    z2 = 1001
            Console.WriteLine(z1);
            Console.WriteLine(z2);

            //NOT
            Console.WriteLine(!true);   //false
            Console.WriteLine(!!true);  //true


            //Binary
            //Modulus
            //integer division: take care becaure int / int = int
            Console.WriteLine(9/4);     //== 2
            //9/4 = 2 remainder 1 = 2 1/4
            //int part is easy. divide ints
            //modulus does the thing
            Console.WriteLine(9%4);

            //Proper decimal division, then 1 number has to be non int
            Console.WriteLine(9.0 / 4);

            //Ternary operator
            //if(condition) ? return this if true : return this if false;

            Console.WriteLine((10 > 4) ? "high" : "low");

            //Nullable
            int number = 100;
            int? number2 = 1000;

            //number 2 i useful if we read from a database and its possible the box is blank
            //if its blank it returns null
            number2 = null;

            //null coalesce
            //shorthand for 
            //if value then return value else return null
            Console.WriteLine("somevalue" ?? "return this if null");
            Console.WriteLine(null ?? "return this if null");

            //Default value
            int somenumber = default;   //assigns 0
            string? somenumber2 = default;
            Console.WriteLine(somenumber);
            Console.WriteLine(somenumber2);
            Console.WriteLine((somenumber2 == null) ? somenumber2 : "not null");
            if (somenumber2 == null)
            {
                Console.WriteLine("its null");
            }

            //bit shift
            //1010 = 10
            //shift to right
            //0101 = 5
            //divided by 2
            
            //1010 = 10
            //shift left
            //10100 = 20
            //times 2
        }
    }
}
