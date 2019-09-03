using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_01_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Console.WriteLine(GetVowelCount("asdfghjkl"));
        }

        public static int GetVowelCount(string str)
        {
            int vowelCount = 0;

            // Your code here
            for(int i = 0; i < str.Length;i++)
            {
                if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u')
                {
                    vowelCount++;
                }
            }


            return vowelCount;
        }
    }
}
