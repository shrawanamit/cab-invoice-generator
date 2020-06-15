namespace ConsoleApp2
{
    public class InvoiceGenerator
    {
        // create constant field to calculate fare
        private static readonly int COST_PER_TIME = 1;
        private static readonly int MINIMUM_Cost_PER_KILOMETER = 10;
        
        /// <summary>
        /// calculate total fare 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns>total fare</returns>
        public double CalculateFare(double distance, int time)
        {
            return distance * MINIMUM_Cost_PER_KILOMETER + time * COST_PER_TIME;
        }
    }
}
