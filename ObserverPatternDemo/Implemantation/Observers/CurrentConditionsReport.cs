using System;
using System.Threading;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Represents current conditions report.
    /// </summary>
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo currentWeatherInformation;

        private static readonly Lazy<CurrentConditionsReport> instance =
            new Lazy<CurrentConditionsReport>(() => new CurrentConditionsReport(), LazyThreadSafetyMode.PublicationOnly);

        public static CurrentConditionsReport Instance { get => instance.Value; }

        private CurrentConditionsReport() { }

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            currentWeatherInformation = info;
        }

        public string GetCurrentConditionsReport()
        {
            return currentWeatherInformation.ToString();
        }
    }
}