using NUnit.Framework;
using ConsoleApp2;

namespace NUnitTestProject1
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
       [SetUp]
        public void Setup()
        {
             invoiceGenerator = new InvoiceGenerator();
        }
        /// <summary>
        /// given distance and time should return total fare 
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_shouldReturn_TotalFare()
        {
            
            double distance = 2.0;
            int time = 5;
            double fare=invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(25,fare);
        }
        /// <summary>
        /// given distance and time should return minimum fare
        /// </summary>
        [Test]
        public void GivenLessDistanceOrTime_shouldReturn_TotalFare()
        {
           // InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 0.1;
            int time = 1;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5, fare);
        }
        /// <summary>
        /// multipal ride return total fare
        /// </summary>
        [Test]
        public void GivenMultipalRide_shouldReturn_InvoiceSummaery()
        {
            //InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides ={ new Ride(2.0, 5),
                            new Ride(0.1,1)
                            };
           
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}