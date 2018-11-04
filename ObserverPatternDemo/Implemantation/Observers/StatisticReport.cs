using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport : IObserver<WeatherInfo>
    {
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
