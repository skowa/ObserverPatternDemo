using ObserverPatternDemo.Implemantation.Observable;
using System;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            throw new NotImplementedException();
        }
    }
}