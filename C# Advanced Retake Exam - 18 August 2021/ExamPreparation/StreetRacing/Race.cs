namespace StreetRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (Capacity > Count 
                && car.HorsePower <= MaxHorsePower
                && Participants.All(x => x.LicensePlate != car.LicensePlate))
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car car = FindParticipant(licensePlate);

            if (car == null)
            {
                return false;
            }

            Participants.Remove(car);

            return true;
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
