using System;

public class TemperatureChangedEventArgs : EventArgs
{
    public float Temperature { get; }
    public TemperatureChangedEventArgs(float temp) => Temperature = temp;
}

public class TemperatureSensor
{
    public event EventHandler<TemperatureChangedEventArgs> OnTemperatureChanged;

    private float _currentTemperature;
    public float CurrentTemperature
    {
        get => _currentTemperature;
        set
        {
            _currentTemperature = value;
            OnTemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(value));
        }
    }
}

public class Display
{
    public void OnUpdate(object sender, TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"[Display] Temperature: {e.Temperature}°C");
    }
}

public class AirConditioner
{
    public void OnUpdate(object sender, TemperatureChangedEventArgs e)
    {
        if (e.Temperature < 17)
            Console.WriteLine("[AirConditioner] Heating ON");
        else if (e.Temperature > 25)
            Console.WriteLine("[AirConditioner] Cooling ON");
        else
            Console.WriteLine("[AirConditioner] OFF");
    }
}

public class SecuritySystem
{
    public void OnUpdate(object sender, TemperatureChangedEventArgs e)
    {
        if (e.Temperature > 40)
            Console.WriteLine("[SecuritySystem] OVERHEAT WARNING!");
        else if (e.Temperature < 5)
            Console.WriteLine("[SecuritySystem] FREEZE WARNING!");
    }
}

class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        Display display = new Display();
        AirConditioner ac = new AirConditioner();
        SecuritySystem security = new SecuritySystem();

        sensor.OnTemperatureChanged += display.OnUpdate;
        sensor.OnTemperatureChanged += ac.OnUpdate;
        sensor.OnTemperatureChanged += security.OnUpdate;

        sensor.CurrentTemperature = 20;
        sensor.CurrentTemperature = 10;
        sensor.CurrentTemperature = 30;
        sensor.CurrentTemperature = 45;
        sensor.CurrentTemperature = 2;
    }
}