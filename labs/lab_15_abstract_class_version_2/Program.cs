using System;

namespace lab_15_abstract_class_version_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "Hello World";
            if (x.StartsWith("Hello"))
            {
                Console.WriteLine(AddingToStrings.AmazingExtraStringMethod("Hello", "World!"));
            }
        }
    }

    public static class AddingToStrings
    {
        public static string AmazingExtraStringMethod(string str, string stringToAdd)
        {
            return _ = str + " " + stringToAdd;
        }
    }
}