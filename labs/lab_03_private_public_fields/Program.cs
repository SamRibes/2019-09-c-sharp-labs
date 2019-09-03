using System;

namespace lab_03_private_public_fields
{
    class Program
    {
        static void Main(string[] args)
        {
            var person01 = new Person();
            person01.name = "Fantasia";
            //person01.NINo = "stuff";      Doesn't work;
            person01.SetNINo("asdfghkjl");
            Console.WriteLine($"{person01.name}'s NINo is {person01.GetNINo()}.");
        }

        class Person
        {
            private string NINo;
            public string name;
            public int age;


            public string GetNINo(){return NINo;}

            public void SetNINo(string newNino){this.NINo = newNino;}

        }
    }
}
