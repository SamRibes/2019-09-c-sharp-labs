using System;

namespace labs_Just_Do_it_17_enum_with_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TestEnums.GetDayMonth(1,1));
        }
    }
    public class TestEnums
    {
        enum Day { Sun = 1, Mon, Tue, Wed, Thu, Fri, Sat };
        enum Month { Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };

        public static (string, string) GetDayMonth(int day, int month)
        {
            return (
                ((Day)day).ToString(),
                ((Month)month).ToString());      //Custom/Anon datatype without a name
        }
    }
}
