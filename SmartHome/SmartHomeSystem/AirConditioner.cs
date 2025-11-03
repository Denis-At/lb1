using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class AirConditioner:Device, IEnergyConsumer
    {
        private const int ACPowerConsumption = 2000; 
        public string DeviceName => Name;
        public int PowerConsumption => ACPowerConsumption;
        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} почав охолодження.");
        }
        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} зупинено.");
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
