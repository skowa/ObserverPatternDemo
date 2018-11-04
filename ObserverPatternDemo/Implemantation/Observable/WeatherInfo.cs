using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo, ICloneable
    {
        public WeatherInfo(int temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }

        public WeatherInfo Clone() => new WeatherInfo(Temperature, Humidity, Pressure);

        object ICloneable.Clone() => Clone();
    }
}