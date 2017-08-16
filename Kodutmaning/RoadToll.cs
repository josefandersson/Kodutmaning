using System;

namespace Kodutmaning
{
    class RoadToll
    {

        public static double CalculateTollPrice(VehicleType vehicleType, int vehicleWeight, DateTime timeOfPassing, bool environmentFriendly = false)
        {
            double price = 0;

            if (environmentFriendly == false)
            {

                if (timeOfPassing == null)
                {
                    timeOfPassing = DateTime.Now;
                }


                if (vehicleType == VehicleType.TRUCK)
                {
                    price = 2000;
                }
                else
                {
                    if (vehicleWeight < 1000)
                    {
                        price = 500;
                    }
                    else
                    {
                        price = 1000;
                    }


                    if (vehicleType == VehicleType.MOTORCYCLE)
                    {
                        price *= 0.7;
                    }
                }


                if (timeOfPassing.DayOfWeek == DayOfWeek.Saturday
                    || timeOfPassing.DayOfWeek == DayOfWeek.Sunday
                    || SwedishHolidays.isSwedishHoliday(timeOfPassing))
                {
                    price *= 2;
                }
                else
                {
                    if (18 <= timeOfPassing.Hour
                        || timeOfPassing.Hour <= 6)
                    {
                        price *= 0.5;
                    }
                }

            }
            
            return price;
        }

    }
}
