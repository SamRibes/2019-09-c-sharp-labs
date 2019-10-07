using NUnit.Framework;
using labs_Just_Do_it_17_enum_with_tests;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup(){}

        [TestCase(1, 2, "Sun", "Feb")]
        [TestCase(1, 3, "Sun", "Mar")]
        [TestCase(1, 4, "Sun", "Apr")]
        [TestCase(1, 5, "Sun", "May")]
        public void TestEnumsGetDayMonth(int day, int month, string expectedDay, string expectedMonth)
        {
            //arrange

            //act
            var act = TestEnums.GetDayMonth(day, month);
            //assert
            Assert.AreEqual(act, (expectedDay,expectedMonth));
        }
    } 
}