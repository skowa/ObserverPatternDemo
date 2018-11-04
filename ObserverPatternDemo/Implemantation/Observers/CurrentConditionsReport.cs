using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo _currentWeatherInfo;

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            _currentWeatherInfo = info?.Clone() ?? throw new ArgumentNullException(nameof(info));
        }

        public override string ToString()
        {
            return
                "Current conditions report: " + 
                $"temperature is {_currentWeatherInfo.Temperature}, humidity is {_currentWeatherInfo.Humidity}, pressure is {_currentWeatherInfo.Pressure}";
        }
    }
}