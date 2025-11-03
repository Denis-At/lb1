using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class CoffeeMachine:Device, IEnergyConsumer
    {
        private const int CoffeeMachinePowerConsumption = 1000; 
        public string DeviceName => Name;
        public int PowerConsumption => CoffeeMachinePowerConsumption;
        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} почала готувати каву.");
        }
        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} завершила роботу.");
        }
        public double GetEnergyUsage(int hours)
        {
            if(!IsOn)
            {
                return 0;
            }
            return (double)PowerConsumption * hours / 1000.0;
        }
    }
}
