using System;

namespace lab_37_overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            short s = 12345;
            int i = 1234567890;
            long l = 1234567890123456789;
            float f = 123456789012345678901234567890.123456789012345678901234567890F;
            double d = 123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.123456789012345678901234567890;
            decimal dd = 12345678901234567890123456789.123456789012345678901234567890M;

            Console.WriteLine(f);
            Console.WriteLine(d);
            Console.WriteLine(dd);


            //unchecked by default because cpu intensive
            unchecked  //unchecked
            {
                //integer maximums
                var bigInt = int.MaxValue;

                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                DoThis();
            }
        }

        static int counter = 0;
        static void DoThis()
        {
            counter++;
            Console.WriteLine("DoingThis" + counter);
            DoThis();
        }
    }
}
