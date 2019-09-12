using System;
using System.IO;

namespace lab_26_execption_handling
{
    class Program
    {
        static void Main(string[] args)
        {

            //an error is when your bank calcs your interest incorrectly
            //Exception is when your code crashes and it cannot continue
            //handled
            //Exception takes place in a try block and the code is handled in the catch block
            //Whether Exception or not they run finally block
            //unhandled
            //messy Exception progerma terminates uncleanly 
            //compiler
            //red line it will not build
            //runtime
            //compiles but crashes during runtime

            int x = 10, y = 0;

            //Console.WriteLine(x / y);
            //unhandled Exception

            try
            {
                //any code with might produce an expection
                //eg 10/0
                Console.WriteLine(x/y); //Throws Expection
            }
            catch(Exception e)
            {
                Console.WriteLine("Don't do that");
                Console.WriteLine(e);
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally do this");
            }

            //Custom Exception
            var myException = new Exception("Hey this is a Sam special");

            try
            {
                //Imagine engine is getting hot but hasnt burnt out yet
                throw (myException);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //LARGE APPLICATION
            //layers of nesting
            //MAIN
            //SUB
            //SUB

            try
            {
                try
                {
                    try
                    {
                        throw (new Exception("inner exception - Sams code"));
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                catch(Exception e)
                {
                    throw;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                File.WriteAllText("log.txt", $"Umm Phil Phil's code not working again... typical - {e.Message}");
            }

            //Different Types of expections
            try
            {

            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Don't do that");
            }
            catch(Exception e)
            {
                Console.WriteLine("All Exceptions");
            }
        }
    }
}
