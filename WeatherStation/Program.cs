using System;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherInfo weather_1 = new WeatherInfo(16, 20, 101322);
            WeatherInfo weather_2 = new WeatherInfo(22, 26, 101324);
            WeatherInfo weather_3 = new WeatherInfo(25, 22, 101326);
            WeatherInfo weather_4 = new WeatherInfo(17, 40, 101328);
            WeatherInfo weather_5 = new WeatherInfo(19, 23, 101330);

            WeatherData weatherData = WeatherData.Instance;

            CurrentConditionsReport report = CurrentConditionsReport.Instance;
            StatisticReport statistic = StatisticReport.Instance;

            weatherData.Register(report);
            weatherData.Register(statistic);

            weatherData.Notify(weatherData, weather_1);
            weatherData.Notify(weatherData, weather_2);
            weatherData.Notify(weatherData, weather_3);

            Console.WriteLine(report.GetCurrentConditionsReport());
            Console.WriteLine(statistic.GetStatisticReport());

            weatherData.Unregister(statistic);

            weatherData.Notify(weatherData, weather_4);
            weatherData.Notify(weatherData, weather_5);

            Console.WriteLine(report.GetCurrentConditionsReport());
            Console.WriteLine(statistic.GetStatisticReport());
        }
    }
}
