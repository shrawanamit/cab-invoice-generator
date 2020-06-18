using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    
    public class Ride
    {
        public InvoiceGenerator.Journey journey;
        public readonly double distance;
        public readonly int time;

        public Ride(InvoiceGenerator.Journey journey,double distance, int time)
        {
            this.journey = journey;
            this.distance = distance;
            this.time = time;
        }
    }
}
