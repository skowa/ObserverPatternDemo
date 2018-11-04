using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        private readonly List<IObserver<WeatherInfo>> _observers = new List<IObserver<WeatherInfo>>();
        
        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            foreach (IObserver<WeatherInfo> observer in _observers)
            {
                observer.Update(sender, info);
            }
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            if (_observers.Contains(observer))
            {
                throw new ArgumentException(nameof(observer));
            }

            _observers.Add(observer);
        }

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
    }
}