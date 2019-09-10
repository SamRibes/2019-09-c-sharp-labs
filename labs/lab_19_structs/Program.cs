using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_19_structs
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new MyStruct();
            var s2 = new MyStruct(1, 2, "asdfg");
            Console.WriteLine(s2.GetX());
        }

        class MyClass
        {

        }

        struct MyStruct
        {
            private int x;
            public int y;
            public string z { get; set; }
            public MyStruct(int x, int y, string z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public int GetX()
            {
                return this.x;
            }
        }

       
    }
}
