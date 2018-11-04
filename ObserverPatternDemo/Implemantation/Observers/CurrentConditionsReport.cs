using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            throw new System.NotImplementedException();
        }
    }
}