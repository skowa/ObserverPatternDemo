using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            throw new NotImplementedException();
        }

        public void Register(IObserver<WeatherInfo> observer)
        {
            throw new NotImplementedException();
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            throw new NotImplementedException();
        }
    }
}
