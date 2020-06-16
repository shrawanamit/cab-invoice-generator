namespace ConsoleApp2
{
    public class InvoiceGenerator
    {
        // create constant field to calculate fare
        private static readonly int COST_PER_TIME = 1;
        private static readonly double MINIMUM_Cost_PER_KILOMETER = 10;
        private static readonly double MINIMUM_FARE = 5;
        /// <summary>
        /// calculate total fare 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns>total fare</returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * MINIMUM_Cost_PER_KILOMETER + time * COST_PER_TIME;
            if(totalFare < MINIMUM_FARE)
                return MINIMUM_FARE;
            return totalFare;
        }
    }
}
