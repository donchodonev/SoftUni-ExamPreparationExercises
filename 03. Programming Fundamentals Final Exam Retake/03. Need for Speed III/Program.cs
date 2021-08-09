using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class CarAttr
    {
        public CarAttr(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, CarAttr> cars = new Dictionary<string, CarAttr>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] CarAttrArgs = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string name = CarAttrArgs[0];
                int mileage = int.Parse(CarAttrArgs[1]);
                int fuel = int.Parse(CarAttrArgs[2]);

                cars.Add(name,new CarAttr(mileage,fuel));
            }

            string[] cmdArgs = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while (command != "Stop")
            {
                if (command == "Drive")
                {
                    string name = cmdArgs[1];
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);

                    Drive(name, distance, fuel);
                }
                else if (command == "Refuel")
                {
                    string name = cmdArgs[1];
                    int fuel = int.Parse(cmdArgs[2]);

                    Refuel(name, fuel);
                }
                else
                {
                    string name = cmdArgs[1];
                    int mileage = int.Parse(cmdArgs[2]);

                    Revert(name,mileage);
                }

                cmdArgs = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                command = cmdArgs[0];
            }

            foreach (var car in cars.OrderByDescending(x => x.Value.Mileage)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }

            void Drive(string name, int distance, int fuel)
            {
                if (cars[name].Fuel < fuel)
                {
                    Console.WriteLine("Not enough fuel to make that ride");
                }
                else
                {
                    cars[name].Mileage += distance;
                    cars[name].Fuel -= fuel;
                    Console.WriteLine($"{name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                }

                if (cars[name].Mileage >= 100000)
                {
                    Console.WriteLine($"Time to sell the {name}!");
                    cars.Remove(name);
                }
            }

            void Refuel(string name, int fuel)
            {
                int maxFuel = 75;
                int currentFuel = cars[name].Fuel;

                if (currentFuel + fuel > maxFuel)
                {
                    cars[name].Fuel = maxFuel;
                    Console.WriteLine($"{name} refueled with {maxFuel - currentFuel} liters");
                }
                else
                {
                    cars[name].Fuel += fuel;
                    Console.WriteLine($"{name} refueled with {fuel} liters");
                }
            }

            void Revert(string name, int mileage)
            {
                int currentMileage = cars[name].Mileage;
                int minMileage = 10000;

                if ((currentMileage -= mileage) < minMileage)
                {
                    cars[name].Mileage = minMileage;
                }
                else
                {
                    cars[name].Mileage -= mileage;
                    Console.WriteLine($"{name} mileage decreased by {mileage} kilometers");
                }
            }
        }
    }
}
