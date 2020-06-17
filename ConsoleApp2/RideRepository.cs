using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class RideRepository
    {
        Dictionary<string,List<Ride>> userRides= null;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>() ;
        }
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            if (rideList == false)
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                this.userRides.Add(userId, list);
            }
        }

        /// <summary>
        ///  Used To Fetch the Number Of Rides Based On the UserId
        /// </summary>
        /// <returns>It returns the Total Rides of that Particular UserId</returns>
        public Ride[] GetRides(string userId)
        {
            return this.userRides[userId].ToArray();
        }

    }
}
