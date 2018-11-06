using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    /// <summary>
    /// This is class-observer of current conditions report.
    /// </summary>
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo _currentWeatherInfo;

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

            _currentWeatherInfo = info?.Clone() ?? throw new ArgumentNullException(nameof(info));
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
        /// Represents report about current weather.
        /// </summary>
        /// <returns>
        /// The instance of <see cref="CurrentConditionsReport"/> as a string.
        /// </returns>
        public override string ToString()
        {
            if (_currentWeatherInfo == null)
            {
                return "There is no data about current weather";
            }

            return
                "Current conditions report: " + 
                $"temperature is {_currentWeatherInfo.Temperature}, humidity is {_currentWeatherInfo.Humidity}, pressure is {_currentWeatherInfo.Pressure}";
        }
    }
}