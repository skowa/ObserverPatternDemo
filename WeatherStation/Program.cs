using System;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            
            var currentReport = new CurrentConditionsReport();
            var statisticReport = new StatisticReport();

            weatherData.Register(currentReport);
            weatherData.Register(statisticReport);

            weatherData.Notify(weatherData, new WeatherInfo(10, 45, 12));
            Console.WriteLine(currentReport);

            weatherData.Notify(weatherData, new WeatherInfo(15, 90, 10));
            Console.WriteLine(currentReport);

            weatherData.Notify(weatherData, new WeatherInfo(25, 30, 12));
            Console.WriteLine(currentReport);

            weatherData.Unregister(currentReport);

            weatherData.Notify(weatherData, new WeatherInfo(0, 30, 12));
            Console.WriteLine(statisticReport);

            weatherData.Unregister(statisticReport);
        }
    }
}
