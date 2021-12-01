namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using static CarRacing.Utilities.Messages.ExceptionMessages;

    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumtpionPerRace;

        protected Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            this.VIN = VIN;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidCarMake);
                }
                make = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidCarModel);
                }
                model = value;
            }
        }

        public string VIN
        {
            get => vin;
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(InvalidCarVIN);
                }
                vin = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarHorsePower);
                }
                horsePower = value;
            }
        }


        public double FuelAvailable
        {
            get => fuelAvailable;
            private set
            {
                if (value < 0)
                {
                    fuelAvailable = 0;
                }

                fuelAvailable = value;
            }
        }


        public double FuelConsumptionPerRace
        {
            get => fuelConsumtpionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarFuelConsumption);
                }
                fuelConsumtpionPerRace = value;
            }
        }


        public virtual void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
