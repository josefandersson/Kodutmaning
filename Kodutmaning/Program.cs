using System;

namespace Kodutmaning
{
    class Program
    {
        static void Main(string[] args)
        {
            testRoadToll(VehicleType.MOTORCYCLE, 300, new DateTime(2017, 1, 1, 15, 30, 0), 700); // nyårsdagen
            testRoadToll(VehicleType.CAR, 1450, new DateTime(2017, 4, 14, 19, 20, 0), 2000);     // långfredagen år 2017
            testRoadToll(VehicleType.TRUCK, 9000, new DateTime(2017, 6, 4, 20, 0, 0), 4000);     // pingstdagen år 2017
            testRoadToll(VehicleType.TRUCK, 8600, new DateTime(2017, 3, 12, 12, 0, 0), 4000);    // vanlig söndag
            testRoadToll(VehicleType.CAR, 1001, new DateTime(2016, 3, 11, 12, 0, 0), 1000);      // vanlig fredag
            testRoadToll(VehicleType.CAR, 999, new DateTime(2016, 3, 11, 12, 0, 0), 500);        // vanlig fredag
            testRoadToll(VehicleType.MOTORCYCLE, 400, new DateTime(2016, 3, 9, 12, 0, 0), 350);  // vanlig onsdag
            testRoadToll(VehicleType.TRUCK, 7500, new DateTime(2016, 3, 7, 12, 0, 0), 2000);     // vanlig måndag

            Console.ReadKey();
        }

        private static void testRoadToll(VehicleType vehicleType, int vehicleWeight, DateTime timeOfPassing, int expectedOutput, bool environmentFriendly = false)
        {
            int output = (int) RoadToll.CalculateTollPrice(vehicleType, vehicleWeight, timeOfPassing, environmentFriendly);

            Console.WriteLine("{0}, {1}kg, {2} => {3}SEK (should give {4}SEK) \tSuccess:{5}",
                vehicleType,
                vehicleWeight,
                timeOfPassing,
                output,
                expectedOutput,
                output == expectedOutput);
        }
    }
}
