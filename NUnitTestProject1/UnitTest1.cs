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
        /// <summary>
        /// Given More Rides and Empty UserId returns the Exception
        /// </summary>
        [Test]
        public void GivenEmptyUserIdAndRides_ShouldReturn_InvoiceSummary()
        {
            try
            {
                string userId = "";
                Ride[] rides = { new Ride(InvoiceGenerator.Journey.NORMAL,2.0,5),//25
                                 new Ride(InvoiceGenerator.Journey.NORMAL,5.0,10)//60
                               };
                invoiceGenerator.addRide(userId, rides);
                InvoiceSummary summary = invoiceGenerator.getInvoiceSummary(userId);
                InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 85.0);
            }
            catch (CabInvoiceException e)
            {
                Assert.AreEqual(CabInvoiceException.ExceptionType.UserIdCanNotBeEmpty, e.type);
            }
        }

        /// <summary>
        /// Given More Rides and Null UserId returns the Exception
        /// </summary>
        [Test]
        public void GivenNullUserIdAndRides_ShouldReturn_InvoiceSummary()
        {
            try
            {
                string userId = null;
                Ride[] rides = { new Ride(InvoiceGenerator.Journey.NORMAL,2.0,5),
                                 new Ride(InvoiceGenerator.Journey.NORMAL,3.0,5)
                               };
                invoiceGenerator.addRide(userId, rides);
                InvoiceSummary summary = invoiceGenerator.getInvoiceSummary(userId);
                InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 60.0);
            }
            catch (CabInvoiceException e)
            {
                Assert.AreEqual(CabInvoiceException.ExceptionType.UserIdCanNotBeNull, e.type);
            }
        }
    }
}