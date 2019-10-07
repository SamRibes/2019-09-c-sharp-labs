using System;
using System.Reflection;

namespace lab_34_assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            //int as an example
            //let's find DLL where INT lives in windows
            //ASSEMBLY

            var myAssembly = Assembly.GetAssembly(typeof(int));

            Console.WriteLine(myAssembly.GetName());

            //foreach(var type in myAssembly.GetTypes())
            //{
            //    Console.WriteLine(type);
            //}

        }
    }
}
