using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, 65.00, 7.5)
        {
        }
        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)(Convert.ToDouble(HorsePower) * 0.97);
        }
    }
}
