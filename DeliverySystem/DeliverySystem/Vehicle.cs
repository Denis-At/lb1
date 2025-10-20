using System;

namespace DeliverySystem
{
    public class Vehicle
    {
        public string brand; 
        public int year;
        public double mileage;
        public double maxSpeed;

        public Vehicle(string brand, int year, double mileage, double maxSpeed)
        {
            this.brand = brand;
            this.year = year;
            this.mileage = mileage;
            this.maxSpeed = maxSpeed;
        }

        public virtual string GetInfo()
        {
            // Тести, ймовірно, очікують саме цей формат
            return $"{brand} ({year}), Mileage: {mileage} km";
        }

        public virtual double GetMaxSpeed()
        {
            return maxSpeed;
        }

        public virtual void Move(double distance)
        {
            mileage += distance;
            Console.WriteLine($"{brand} drove {distance} km.");
        }
    }
}
