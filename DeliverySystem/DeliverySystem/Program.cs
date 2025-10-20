using System;

namespace DeliverySystem
{
    public class Program
    {
        public static void Main()
        {
            Vehicle scooter = new Scooter("Yamaha", 2020, 500, 20);
            Vehicle car = new Car("Toyota", 2018, 20000, 4);
            Vehicle van = new Van("Ford", 2019, 15000, 4, 1000);

            Console.WriteLine(scooter.GetInfo());
            Console.WriteLine($"Max Speed: {scooter.GetMaxSpeed()} km/h");
            scooter.Move(20);
            ((Scooter)scooter).Charge();

            Console.WriteLine();
            Console.WriteLine(car.GetInfo());
            Console.WriteLine($"Max Speed: {car.GetMaxSpeed()} km/h");
            car.Move(50);

            Console.WriteLine();
            Console.WriteLine(van.GetInfo());
            Console.WriteLine($"Max Speed: {van.GetMaxSpeed()} km/h");
            ((Van)van).LoadCargo(800);
            Console.WriteLine(van.GetInfo());
            ((Van)van).LoadCargo(300);
            ((Van)van).UnloadCargo();
        }
    }
}
