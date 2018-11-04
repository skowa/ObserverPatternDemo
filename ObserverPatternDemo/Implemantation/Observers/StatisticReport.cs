using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// Contains methods that help to constitute the weather conditions statistic.
    /// </summary>
    /// <seealso cref="ObserverPatternDemo.IObserver{ObserverPatternDemo.Implemantation.Observable.WeatherInfo}" />
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private static readonly Lazy<StatisticReport> instance =
            new Lazy<StatisticReport>(() => new StatisticReport(), LazyThreadSafetyMode.PublicationOnly);

        public static StatisticReport Instance { get => instance.Value; }

        private StatisticReport() { }

        private List<WeatherInfo> listOfWeatherConditions = new List<WeatherInfo>();

        /// <summary>
        /// Adds weather notifications in special repository.
        /// </summary>
        /// <param name="sender">The object that is to raised notifications.</param>
        /// <param name="info">The current notification information.</param>
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            listOfWeatherConditions.Add(info);
        }

        /// <summary>
        /// Gets the statistic report.
        /// </summary>
        /// <returns>Statistic report in string representation.</returns>
        public string GetStatisticReport()
        {
            if (listOfWeatherConditions.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder statistic = new StringBuilder();
            statistic.Append('*', 30);
            statistic.Append(" Statistic Report ");
            statistic.Append('*', 30);
            statistic.Append("\n");

            for (int i = 0; i < listOfWeatherConditions.Count; i++)
            {
                statistic.Append(listOfWeatherConditions[i] + "\n");
            }
            statistic.Append('*', 78);
            return statistic.ToString();
        }
    }
}
