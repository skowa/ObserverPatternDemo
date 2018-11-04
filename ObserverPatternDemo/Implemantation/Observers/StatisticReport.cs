using System;
using System.Collections.Generic;
using System.Text;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private List<WeatherInfo> _weatherInfoList = new List<WeatherInfo>();

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            _weatherInfoList.Add(info.Clone());
        }

        public override string ToString()
        {
            var report = new StringBuilder("Statistics:");
            foreach (WeatherInfo info in _weatherInfoList)
            {
                report.Append(
                    $"\nTemperature is {info.Temperature}, humidity is {info.Humidity}, pressure is {info.Pressure}");
            }

            return report.ToString();
        }
    }
}
