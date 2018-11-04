namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Represents information about weather conditions.
    /// </summary>
    /// <seealso cref="ObserverPatternDemo.EventInfo" />
    public class WeatherInfo : EventInfo
    {
        private int Temperature { get; set; }
        private int Humidity { get; set; }
        private int Pressure { get; set; }

        public WeatherInfo(int temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        public override string ToString()
        {
            return string.Format($"Current weather information:\nTemperature: {Temperature}\nHumidity: {Humidity}\nPressure: {Pressure}\n");
        }

    }
}