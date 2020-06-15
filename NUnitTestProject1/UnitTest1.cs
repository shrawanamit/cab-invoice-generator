using NUnit.Framework;
using ConsoleApp2;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// given distance and time should return total fare 
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_shouldReturn_TotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;
            double fare=invoiceGenerator.calculateFare(distance, time);
            Assert.AreEqual(25,fare);
        }
    }
}