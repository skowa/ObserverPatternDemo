using System;
using System.Collections.Generic;
using System.Timers;

namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// This is weather data class.
    /// </summary>
    public class WeatherData : IObservable<WeatherInfo>
    {
        private readonly List<IObserver<WeatherInfo>> _observers = new List<IObserver<WeatherInfo>>();

        private WeatherInfo _currentWeatherInfo = new WeatherInfo();

        private WeatherInfo _previousWeatherInfo = new WeatherInfo();

        private Timer _timer;

        /// <summary>
        /// Gets or sets current weather info.
        /// </summary>
        public WeatherInfo CurrentWeatherInfo
        {
            get => _currentWeatherInfo;
            set => _currentWeatherInfo = value?.Clone() ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// The method that starts checking changing of <see cref="CurrentWeatherInfo"/>
        /// </summary>
        /// <param name="interval">
        /// The interval of repeating event.
        /// </param>
        public void StartCheckingData(double interval)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += (o, e) => CheckData();
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        /// <summary>
        /// The method that stops checking changing of <see cref="CurrentWeatherInfo"/>
        /// </summary>
        public void StopCheckingData()
        {
            _timer.Stop();
            _timer.Dispose();
        }

        /// <summary>
        /// Registers the observer
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        public void Register(IObserver<WeatherInfo> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            _observers.Add(observer);
        }

        /// <summary>
        /// Unregisters the observer
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            if (!_observers.Contains(observer))
            {
                throw new ArgumentException(nameof(observer));
            }

            _observers.Remove(observer);
        }

        void IObservable<WeatherInfo>.Notify(WeatherInfo info) => Notify(info);

        protected virtual void Notify(WeatherInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            foreach (IObserver<WeatherInfo> observer in _observers)
            {
                observer.Update(this, info);
            }
        }

        private void CheckData()
        {
            if (!_previousWeatherInfo.Equals(CurrentWeatherInfo))
            {
                Notify(CurrentWeatherInfo);
                _previousWeatherInfo = CurrentWeatherInfo.Clone();
            }
        }
    }
}