using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    
    public class Ride
    {
        public readonly double distance;
        public readonly int time;

        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
