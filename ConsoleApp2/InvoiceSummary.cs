using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class InvoiceSummary
    {
        private readonly int noOfRide;
        private readonly double totalFare;
        private readonly double average;

        public InvoiceSummary(int noOfRide, double totalFare)
        {
            this.noOfRide = noOfRide;
            this.totalFare = totalFare;
            this.average = this.totalFare / this.noOfRide;
        }

        public override bool Equals(object obj)
        {
            return obj is InvoiceSummary summary &&
                   noOfRide == summary.noOfRide &&
                   totalFare == summary.totalFare &&
                   average == summary.average;
        }
    }
}
