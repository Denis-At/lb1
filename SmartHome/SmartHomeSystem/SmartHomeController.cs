using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private readonly List<ISwitchable> _allDevices = new List<ISwitchable>();

        private readonly List<IEnergyConsumer> _energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            _allDevices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            _energyDevices.Add(device);
        }

        public void TurnAllOn()
        {
            foreach (var device in _allDevices)
            {
                device.TurnOn();
            }
        }

        public void TurnAllOff()
        {
            foreach (var device in _allDevices)
            {
                device.TurnOff();
            }
        }

        public void ShowEnergyReport(int hours)
        {
            var ukCulture = new CultureInfo("uk-UA");

            Console.WriteLine($"Звіт про споживання енергії за {hours} год:");

            double totalConsumption = 0;

            foreach (var energyDevice in _energyDevices)
            {
                double usage = energyDevice.GetEnergyUsage(hours);
                totalConsumption += usage;

                Console.WriteLine($"{energyDevice.DeviceName}: {usage.ToString("F2", ukCulture)} кВт·год (потужність: {energyDevice.PowerConsumption} Вт)");
            }

            Console.WriteLine($"Загальне споживання: {totalConsumption.ToString("F2", ukCulture)} кВт·год");

            Console.WriteLine($"Вартість (~4 грн/кВт·год): {(totalConsumption * 4.0).ToString("F2", ukCulture)} грн");
        }
    }
}