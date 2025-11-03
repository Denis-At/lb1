using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHomeSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var controller = new SmartHomeController();

            var livingRoomLight = new Light { Name = "Лампа у вітальні" };
            var bedroomAC = new AirConditioner { Name = "Кондиціонер у спальні" };
            var kitchenCoffeeMachine = new CoffeeMachine { Name = "Кавомашина на кухні" };
            var hallwaySensor = new MotionSensor { Name = "Датчик руху у коридорі" };

            var allDevices = new List<Device> { livingRoomLight, bedroomAC, kitchenCoffeeMachine, hallwaySensor };

            controller.AddDevice(livingRoomLight);
            controller.AddDevice(bedroomAC);
            controller.AddDevice(kitchenCoffeeMachine);
            controller.AddDevice(hallwaySensor);

            controller.AddEnergyDevice(livingRoomLight);
            controller.AddEnergyDevice(bedroomAC);
            controller.AddEnergyDevice(kitchenCoffeeMachine);

            controller.TurnAllOn(); 

            Console.WriteLine();

            foreach (var device in allDevices)
            {
                device.PrintStatus(); 
            }

            Console.WriteLine();

            controller.ShowEnergyReport(5);

            controller.TurnAllOff(); 
        }
    }
}