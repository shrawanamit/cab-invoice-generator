using NUnit.Framework;
using ConsoleApp2;

namespace NUnitTestProject1
{
    public class Tests
    {
        //instance of invoice generator
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
        }

        /// <summary>
        /// given distance and time should return total fare normal
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_shouldReturn_TotalFare()
        {

            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(InvoiceGenerator.Journey.NORMAL,distance, time);
            Assert.AreEqual(25, fare);
        }

        /// <summary>
        /// given distance and time should return total fare Premium
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_shouldReturn_TotalFarePremium()
        {

            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(InvoiceGenerator.Journey.PREMIUM, distance, time);
            Assert.AreEqual(40, fare);
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
            double fare = invoiceGenerator.CalculateFare(InvoiceGenerator.Journey.NORMAL,distance, time);
            Assert.AreEqual(5, fare);
        }

        /// <summary>
        /// multipal ride return total fare
        /// </summary>
        [Test]
        public void GivenMultipalRide_shouldReturn_InvoiceSummaery()
        {
            //InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides ={ new Ride(InvoiceGenerator.Journey.NORMAL,2.0, 5),
                            new Ride(InvoiceGenerator.Journey.NORMAL,0.1,1)
                            };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
        [Test]
        /// <summary>
        /// given user id return in voice summary
        /// </summary>
        public void GivenUserIdAndRides_shouldReturn_InvoiceSummaery()
        {
            string userID = "abc.com";
            Ride[] rides ={ new Ride(InvoiceGenerator.Journey.NORMAL,2.0, 5),
                            new Ride(InvoiceGenerator.Journey.NORMAL,0.1,1)
                            };
            invoiceGenerator.addRide(userID,rides);
            InvoiceSummary summary = invoiceGenerator.getInvoiceSummary(userID);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedInvoiceSummary, summary);
        }
    }
}