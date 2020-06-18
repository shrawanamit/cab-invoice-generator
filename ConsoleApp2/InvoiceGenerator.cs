using System;
using System.Reflection.Metadata;

namespace ConsoleApp2
{
    public class InvoiceGenerator
    {
        // create constant field to calculate normal fare
        private const int COST_PER_TIME_NORMAL = 1;
        private const double MINIMUM_Cost_PER_KILOMETER_NORMAL = 10;
        private const double MINIMUM_FARE_NORMAL = 5;

        // create constant field to calculate premimum fare
        public static readonly int MINIMUM_Cost_PER_KILOMETER_PREMIUM = 15;
        public static readonly int COST_PER_TIME_PREMIUM = 2;
        public static readonly double MINIMUM_FARE_PREMIUM = 20;

        //instance of RideRepository

        private readonly RideRepository rideRepository;

        public InvoiceGenerator()
        {
            this.rideRepository = new RideRepository();
        }
        /// <summary>
        /// Enum is used to define PREMIUM NORMAL data types
        /// </summary>
        public enum Journey
        {
            PREMIUM, NORMAL
        }

        /// <summary>
        /// calculate total fare normal
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns>total fare</returns>
        public double CalculateNormalFare(double distance, int time)
        {
            double totalFare = distance * MINIMUM_Cost_PER_KILOMETER_NORMAL + time * COST_PER_TIME_NORMAL;
            if (totalFare < MINIMUM_FARE_NORMAL)
                return MINIMUM_FARE_NORMAL;
            return totalFare;
        }
        /// <summary>
        /// calculate total fare premium
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculatePremimumFare(double distance, int time)
        {
            double totalFare = distance * MINIMUM_Cost_PER_KILOMETER_PREMIUM + time * COST_PER_TIME_PREMIUM;
            if (totalFare < MINIMUM_FARE_PREMIUM)
                return MINIMUM_FARE_PREMIUM;
            return totalFare;
        }

        public double CalculateFare(InvoiceGenerator.Journey journey, double distance, int time)
        {
            if (journey == InvoiceGenerator.Journey.NORMAL)
                return CalculateNormalFare(distance, time);
            return CalculatePremimumFare(distance, time);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalfare = 0;
            foreach(Ride ride in rides)
            {
                totalfare += this.CalculateFare(ride.journey,ride.distance, ride.time);
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
