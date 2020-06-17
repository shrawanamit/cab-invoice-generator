using System;
using System.Reflection.Metadata;

namespace ConsoleApp2
{
    public class InvoiceGenerator
    {
        // create constant field to calculate fare
        private const int COST_PER_TIME = 1;
        private const double MINIMUM_Cost_PER_KILOMETER = 10;
        private const double MINIMUM_FARE = 5;
        private RideRepository rideRepository;

        public InvoiceGenerator(){
            this.rideRepository=new RideRepository();
         }
        /// <summary>
        /// calculate total fare 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns>total fare</returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * MINIMUM_Cost_PER_KILOMETER + time * COST_PER_TIME;
            if (totalFare < MINIMUM_FARE)
                return MINIMUM_FARE;
            return totalFare;
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalfare = 0;
            foreach(Ride ride in rides)
            {
                totalfare += this.CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length,totalfare);
        }

        public void addRide(string userID, Ride[] rides)
        {
            rideRepository.AddRide(userID, rides);
        }

        public InvoiceSummary getInvoiceSummary(string userID)
        {
            return this.CalculateFare(rideRepository.GetRides(userID));
        }
    }
}
