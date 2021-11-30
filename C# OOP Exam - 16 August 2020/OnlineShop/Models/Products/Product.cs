﻿namespace OnlineShop.Models.Products
{
    using System;
    using static OnlineShop.Common.Constants.ExceptionMessages;

    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidProductId);
                }
                id = value;
            }
        }

        public string Manufacturer
        {
            get => manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidManufacturer);
                }
                manufacturer = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidModel);
                }
                model = value;
            }
        }


        public virtual decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidPrice);
                }
                price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => overallPerformance;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidOverallPerformance);
                }
                overallPerformance = value;
            }
        }
        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance:F2}. Price: {price} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})";
        }
    }
}
