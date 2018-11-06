using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo, ICloneable, IEquatable<WeatherInfo>
    {
        public WeatherInfo() { }

        public WeatherInfo(int temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        public int Temperature { get; }
        public int Humidity { get; }
        public int Pressure { get; }

        public WeatherInfo Clone() => new WeatherInfo(Temperature, Humidity, Pressure);

        object ICloneable.Clone() => Clone();

        public bool Equals(WeatherInfo other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Temperature == other.Temperature && Humidity == other.Humidity && Pressure == other.Pressure;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((WeatherInfo) obj);
        }

        public override int GetHashCode()
        {
            return Temperature.GetHashCode() ^ Humidity.GetHashCode() ^ Pressure.GetHashCode();
        }
    }
}