using System;
using System.Collections.Generic;
using System.Text;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// This is class-observer of weather condition statistics.
    /// </summary>
    public class StatisticReport : IObserver<WeatherInfo>
    {
        private readonly List<WeatherInfo> _weatherInfoList = new List<WeatherInfo>();

        /// <summary>
        /// Handles an event.
        /// </summary>
        /// <param name="sender">
        /// The object that is to raised notifications.
        /// </param>
        /// <param name="info">
        /// The current notification information.
        /// </param>
        public void Update(object sender, WeatherInfo info)
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

        /// <summary>
        /// The method that begins object observation.
        /// </summary>
        /// <param name="observable">
        /// An object to be observed.
        /// </param>
        public void StartObserving(IObservable<WeatherInfo> observable)
        {
            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable));
            }

            observable.Register(this);
        }

        /// <summary>
        /// The method that stops object observation. 
        /// </summary>
        /// <param name="observable">
        /// The object to be ended observation for.
        /// </param>
        public void StopObserving(IObservable<WeatherInfo> observable)
        {
            if (observable == null)
            {
                throw new ArgumentNullException(nameof(observable));
            }

            observable.Unregister(this);
        }

        /// <summary>
        /// Represents statistics of weather info.
        /// </summary>
        /// <returns>
        /// The instance of <see cref="StatisticReport"/> as a string.
        /// </returns>
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
