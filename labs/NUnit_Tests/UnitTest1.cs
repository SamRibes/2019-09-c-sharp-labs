using NUnit.Framework;
using Just_Do_It_11_Rabbit_Explosion;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        //public void TestMeSomething_RunTestMeNow_Tests()
        //{
        //    var expected = 100;
        //    var actual = TestMeSomething.RunThisTestNow(10);
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestCase(10, 100)]
        //[TestCase(100, 10000)]
        //[TestCase(9, 82)]
        //public void TestMeSomething_RunTestMeNow_Tests(int input, int expected)
        //{
        //    var actual = TestMeSomething.RunThisTestNow(input);
        //    Assert.AreEqual(expected, actual);
        //    System.Console.WriteLine();
        //}

        [TestCase(1000, 20)]
        public void TestRabbitExplosion (int popLimit, int expectedYears)
        {
            var actual = just_do_it_11_rabbit_explosion.Rabbit_Exponential_Growth(popLimit).ToTuple().Item1;
            Assert.AreEqual(expectedYears, actual);
        }

    }
}