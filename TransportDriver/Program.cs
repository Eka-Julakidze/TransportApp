using System;
using System.Collections.Generic;
using System.Linq;
using TransportNameSpace;
using static TransportNameSpace.Transport;

namespace TransportDriver
{

    class Program
    {
        static void Main(string[] args)
        {           
            var vehicles = new List<Transport>
            {
                new Train("Tblisi", 120),
                new Train("abc", 60),
                new Buss("yellow", 85),
                new Buss("blue", 20),
                new Buss("Brown", 30),
                new Train("Xar", 50),
                new Buss("Old_Buss", 25),
                new Train("RedTrain", 300),
                new Train("YellowTrain", 250),
                new Buss("Red Buss", 45),

               
            };

            var rand = new Random();
            int incr; // increases speed
            Console.WriteLine("\nThe Collection of Vehicles-----------------------------\n".ToUpper());

            // randomly increase speed of each vehicle and then print the info
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"INFO --> {vehicle.GetType().Name.ToUpper()}: {vehicle.ToString()}");
                
                incr = rand.Next(20);                                
                vehicle.IncreaseSpeed(incr);
                Console.WriteLine($"P.S. the speed after increase is: {vehicle.Speed}");
                Console.WriteLine($"Number of Crashed Vehicles: {NumberOfTransportCrash}");

                Console.WriteLine("---------------------------------------");
            }
        }
    }
}
